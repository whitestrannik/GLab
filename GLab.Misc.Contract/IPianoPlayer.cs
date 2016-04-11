using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Contract
{
    [ContractClass(typeof(PianoPlayerContract))]
    internal interface IPianoPlayer
    {
        void PlayFalseNote(NoteBase note);

        int NotePlayedCount { get; }
    }
}
