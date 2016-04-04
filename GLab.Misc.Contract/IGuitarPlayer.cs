using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Contract
{
    internal interface IGuitarPlayer
    {
        void PlayMelody(IEnumerable<NoteBase> melody);

        IEnumerable<NoteBase> HarmonizeMelody(IEnumerable<NoteBase> melody);

        int MelodyPlayedCount { get; }
    }
}
