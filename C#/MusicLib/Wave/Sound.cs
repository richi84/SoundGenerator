using System;
using System.Collections.Generic;

namespace SoundGenerator.Wave
{
    public delegate float Funktion(float x);

    public class Sound
    {
        class SinEntry
        {
            public float Factor { set; get; }
            public float Amplitude { set; get; }
        }

        Funktion amplitudenFunktion;
        List<SinEntry> sinList = new List<SinEntry>();

        public Sound()
        {
            SetAmplitudenFunktion(x => 1);
        }

        public void AddSin(float factor, float amplitude)
        {
            sinList.Add(new SinEntry() { Factor = factor, Amplitude = amplitude });
        }

        public void AddSin(float[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                AddSin(array[i, 0], array[i, 1]);
            }
        }

        private float CalcSinSum(float x)
        {
            float ret = 0;
            sinList.ForEach(v => ret += (float)Math.Sin(x * v.Factor * 2 * Math.PI) * v.Amplitude);
            return ret;
        }

        public void SetAmplitudenFunktion(Funktion function)
        {
            amplitudenFunktion = function;
        }

        public float AmplitudenFunktion(float t)
        {
            return amplitudenFunktion(t);
        }

        public float CalcValue(float v, float t, float f)
        {
            float x = t*f;
            x -= (float)Math.Floor(x);
            return CalcSinSum(x) * amplitudenFunktion(v);
        }


    }
}
