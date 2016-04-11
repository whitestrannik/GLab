using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sys = System.Diagnostics.Contracts;

namespace GLab.Misc.Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            Sys.Contract.ContractFailed += Contract_ContractFailed;

            try
            {
                IGuitarPlayer player = new GuitarPlayer();
                var result = player.HarmonizeMelody(new List<NoteBase>() { new NoteA(), new NoteC()/*, new NoteFalse()*/});
                player.PlayMelody(result);  // All Ok

                result = player.HarmonizeMelody(new List<NoteBase>() { new NoteA(), new NoteFalse() });
                player.PlayMelody(result);  // Exception - exists false note

                player.PlayMelody(new List<NoteBase>()); // Exception - empty list


                IPianoPlayer pianoPlayer = new PianoPlayer();
                pianoPlayer.PlayFalseNote(new NoteFalse()); // All ok
                pianoPlayer.PlayFalseNote(new NoteC()); // Exception
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            Console.ReadLine();
        }

        private static void Contract_ContractFailed(object sender, Sys.ContractFailedEventArgs e)
        {
            Console.WriteLine(e.Message);
            e.SetHandled();           
        }
    }
}
