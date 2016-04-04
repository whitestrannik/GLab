using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Contract
{
    internal abstract class NoteBase
    {
        protected internal NoteBase(char note)
        {
            _note = note;
        }

        char _note;
        internal char NoteSymbol
        {
            get { return _note; }
        }

        public override string ToString()
        {
            return _note.ToString();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;

            NoteBase note = obj as NoteBase;
            if (note == null) return false;

            return note.NoteSymbol == NoteSymbol;
        }

        internal virtual bool IsTrueNote
        {
            get { return true; }
        }

    }

    internal class NoteA : NoteBase
    {
        internal NoteA() : base('A') { }
    }

    internal class NoteC : NoteBase
    {
        internal NoteC() : base('C') { }
    }

    internal class NoteE : NoteBase
    {
        internal NoteE() : base('E') { }
    }

    internal class NoteFalse : NoteBase
    {
        internal NoteFalse() : base('z') { }

        internal override bool IsTrueNote
        {
            get { return false; }
        }
    }

}
