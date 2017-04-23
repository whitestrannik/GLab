using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GLab.Base.Threads
{
    public interface ITaskQueueLauncher
    {
        Task Run(Action<CancellationToken> action, Action<Task> finishedAction);
    }

    public class TaskQueueAsyncLauncher : ITaskQueueLauncher
    {
        private ITaskData _currentTaskData;

        public TaskQueueAsyncLauncher()
        {
            _currentTaskData = new CompletedTaskData();
        }

        public async Task Run(Action<CancellationToken> action, Action<Task> finishedAction)
        {
            var newTaskData = new TaskData(action, finishedAction);

            var prevTaskData = CompareAndExchange(ref _currentTaskData, newTaskData);

            await prevTaskData.CancelAsync().ConfigureAwait(false);

            await newTaskData.RunAsync().ConfigureAwait(false);
        }

        private static ITaskData CompareAndExchange(ref ITaskData taskData, ITaskData newData)
        {
            ITaskData temp;

            do
            {
                temp = taskData;
            }
            while (Interlocked.CompareExchange<ITaskData>(ref taskData, newData, temp) != temp);

            return temp;
        }

        private interface ITaskData
        {
            Task RunAsync();

            Task CancelAsync();
        }

        private sealed class TaskData : ITaskData
        {
            private readonly CancellationTokenSource _cancellationSource;
            private Task _task;
            private readonly Action<CancellationToken> _action;
            private readonly Action<Task> _finishedAction;
            private readonly object _lock;
            private readonly TaskCompletionSource<object> _tcs;

            private readonly Guid _guid = Guid.NewGuid();

            public TaskData(Action<CancellationToken> action, Action<Task> finishedAction)
            {
                _cancellationSource = new CancellationTokenSource();
                _lock = new object();
                _tcs = new TaskCompletionSource<object>();

                _action = action;
                _finishedAction = finishedAction;
            }

            public async Task RunAsync()
            {
                lock (_lock)
                {
                    if (_cancellationSource.IsCancellationRequested)
                    {
                        _finishedAction(CreateCanelledTask());

                        Task.Run(() => _tcs.SetResult(null));

                        return;
                    }
                }

                try
                {
                    _task = Task.Run(() => _action(_cancellationSource.Token), _cancellationSource.Token);
                    await _task.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    _finishedAction(_task);
                    Task.Run(() => _tcs.SetResult(null));
                }
            }

            private Task CreateCanelledTask()
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetCanceled();
                return tcs.Task;
            }

            public async Task CancelAsync()
            {
                lock (_lock)
                {
                    if (!_tcs.Task.IsCompleted)
                    {
                        _cancellationSource.Cancel();
                    }
                }

                await _tcs.Task;
            }
        }

        private sealed class CompletedTaskData : ITaskData
        {
            public Task CancelAsync()
            {
                return Task.FromResult(true);
            }

            public Task RunAsync()
            {
                return Task.FromResult(true);
            }
        }
    }


    public class TaskQueueContinuationLauncher : ITaskQueueLauncher
    {
        private ITaskData _currentTaskData;

        public TaskQueueContinuationLauncher()
        {
            _currentTaskData = new TaskData((c)=> { }, (c) => { });
        }

        public Task Run(Action<CancellationToken> action, Action<Task> finishedAction)
        {
            var newTaskData = new TaskData(action, finishedAction);

            var prevTaskData = CompareAndExchange(ref _currentTaskData, newTaskData);

            return prevTaskData.CancelAndContinueWith(newTaskData);
        }

        private static ITaskData CompareAndExchange(ref ITaskData taskData, ITaskData newData)
        {
            ITaskData temp;

            do
            {
                temp = taskData;
            }
            while (Interlocked.CompareExchange<ITaskData>(ref taskData, newData, temp) != temp);

            return temp;
        }

        private interface ITaskData
        {
            Task Run();

            Task CancelAndContinueWith(ITaskData taskData);
        }

        private sealed class TaskData : ITaskData
        {
            private readonly CancellationTokenSource _cancellationSource;
            private Task _task;
            private readonly Action<CancellationToken> _action;
            private readonly Action<Task> _finishedAction;
            private readonly object _lock;
            private readonly TaskCompletionSource<object> _tcs;

            private readonly Guid _guid = Guid.NewGuid();

            public TaskData(Action<CancellationToken> action, Action<Task> finishedAction)
            {
                _cancellationSource = new CancellationTokenSource();
                _lock = new object();
                _tcs = new TaskCompletionSource<object>();

                _action = action;
                _finishedAction = finishedAction;
            }

            public Task Run()
            {
                lock (_lock)
                {
                    if (_cancellationSource.IsCancellationRequested)
                    {
                        _finishedAction(CreateCanelledTask());
                        return Task.FromResult<object>(null);
                    }
                    else
                    {
                        Console.WriteLine($"Run {_guid}");
                        _task = Task.Run(() => _action(_cancellationSource.Token), _cancellationSource.Token)
                        .ContinueWith(t =>
                        {
                            try
                            { var a = t.Exception; }
                            catch (Exception ex)
                            { }
                            _finishedAction(t);
                        });

                         return _task;
                    }
                }
            }

            private Task CreateCanelledTask()
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetCanceled();
                return tcs.Task;
            }

            public Task CancelAndContinueWith(ITaskData taskData)
            {
                lock (_lock)
                {
                    _cancellationSource.Cancel();

                    if (_task != null)
                    {
                        return _task.ContinueWith((t) => taskData.Run().Wait());
                    }
                    else
                    {
                        return taskData.Run();
                    }
                }
            }
        }
    }
}
