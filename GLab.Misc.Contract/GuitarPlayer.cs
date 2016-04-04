using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Sys = System.Diagnostics.Contracts;

namespace GLab.Misc.Contract
{
    internal class GuitarPlayer : IGuitarPlayer
    {
        public IEnumerable<NoteBase> HarmonizeMelody(IEnumerable<NoteBase> melody)
        {
            Sys.Contract.Requires<ArgumentNullException>(melody != null && melody.Count() > 0);
            // not allow ref to Result<> in exeptional EnsuresOnThrow            
            Sys.Contract.Ensures((Sys.Contract.Result<IEnumerable<NoteBase>>() != null), "Harmonazing is failed");

            return Harmonize(melody);            
        }        

        public void PlayMelody(IEnumerable<NoteBase> melody)
        {
            // Generate ContractException
            Sys.Contract.Requires(melody != null && melody.Count() > 0);
            // Generate ArgumentException
            Sys.Contract.Requires<ArgumentException>(Sys.Contract.ForAll<NoteBase>(melody, (NoteBase item) => { return item.IsTrueNote; }), "False note exists in source");

            foreach (NoteBase note in melody)
                PlayNote(note);

            MelodyPlayedCount++;
        }        

        public int MelodyPlayedCount { get; private set; }
        public int MaxCount { get; private set; } = 5;



        private IEnumerable<NoteBase> Harmonize(IEnumerable<NoteBase> melody)
        {
            return melody;
        }

        private void PlayNote(NoteBase note)
        {            
        }

        [Sys.ContractInvariantMethod]
        private void ValidateGuitarPlayer()
        {
            Sys.Contract.Invariant(MelodyPlayedCount >= 0);
            Sys.Contract.Invariant(MelodyPlayedCount < MaxCount);
        }
    }
}
