using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundGenerator.Wave
{
    public abstract class SinBasedInstrument : IInstrument
    {
        class KlangEntry
        {
            public Sound Klang { set; get; }
            public Funktion Funktion { set; get; }
        }

        List<KlangEntry> klangList = new List<KlangEntry>();

        public SinBasedInstrument()
        {
        }

        public void AddKlang(Sound klang, Funktion funktion)
        {
            klangList.Add(new KlangEntry() { Klang = klang, Funktion = funktion });
        }

        virtual public float CalcValue(float v, float t, float f)
        {
            float ret = 0;
            klangList.ForEach(x => ret += x.Klang.CalcValue(v, t, f)*x.Funktion(v));
            return ret;
        }


    }
}
