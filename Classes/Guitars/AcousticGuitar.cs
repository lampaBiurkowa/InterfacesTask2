using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class AcousticGuitar : IGuitar
    {
        public int StringCount { get; private set; }

        public GuitarTimbre Jerk()
        {
            GuitarTimbre timbre = new GuitarTimbre();
            timbre.Dynamic = true;
            timbre.Loud = false;
            timbre.Synthetic = false;
            return timbre;
        }

        public void Play(IList<INote> notes)
        {
            foreach (var note in notes)
                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note.Frequency)} with timbre {Jerk().Emit()}");
        }
    }
}
