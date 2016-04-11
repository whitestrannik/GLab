using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Contract
{
    internal class PianoPlayer : IPianoPlayer
    {
        public int NotePlayedCount
        {
            get
            {
                return 1;
            }
        }

        public void PlayFalseNote(NoteBase note)
        {
            
        }
    }
}
