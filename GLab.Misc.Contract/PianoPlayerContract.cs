using System;
using System.Diagnostics.Contracts;

using Sys = System.Diagnostics.Contracts;

namespace GLab.Misc.Contract
{
    [ContractClassFor(typeof(IPianoPlayer))]
    internal abstract  class PianoPlayerContract : IPianoPlayer
    {
        public void PlayFalseNote(NoteBase note)
        {
            Sys.Contract.Requires<ArgumentException>(note is NoteFalse);            
        }

        public abstract int NotePlayedCount { get; }
    }
}