using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IGuitarPlayer player = new GuitarPlayer();                
                var result = player.HarmonizeMelody(new List<NoteBase>() { new NoteA(), new NoteC()/*, new NoteFalse()*/});
                player.PlayMelody(result);

                //player.PlayMelody(null); // Will be thrown exception
            }
            catch (Exception ex)
            {
            }
        }
    }
}
