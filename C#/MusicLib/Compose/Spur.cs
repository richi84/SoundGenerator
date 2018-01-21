using SoundGenerator.Wave;
using System;
using System.Collections.Generic;

namespace SoundGenerator.Compose
{
    public abstract class Spur
    {
        public IInstrument Instrument { private set; get; }
        protected Random rnd;

        public Spur(IInstrument instrument, Random rnd)
        {
            Instrument = instrument;
            this.rnd = rnd;
        }

        public abstract List<Tone> GetMelodie(List<Bar> taktList, double schlaglaenge, int schlaegeProTakt);
    }
}