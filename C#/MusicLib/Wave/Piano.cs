using System;

namespace SoundGenerator.Wave
{
    public class Piano : SinBasedInstrument
    {
        public Piano()
        {
            Sound startKlang = new Sound();
            //Stark ansteigend, dann ausklingend y=(2*x^(1/6))*2^-(x*10)
            startKlang.SetAmplitudenFunktion(x => (float)Math.Pow(2.0*x, 1.0 / 6.0) * (float)Math.Pow(2.0, -(10 * x)));
            startKlang.AddSin(new float[6, 2] {   {1f, 1f} , 
                                                  {2f, 0.3f} , 
                                                  {3f, 0.15f} , 
                                                  {4f, 0.2f} , 
                                                  {5f, 0.05f} , 
                                                  {6f, 0.1f} });

            Sound endKlang = new Sound();
            //Stark ansteigend, dann ausklingend y=(2*x^(1/6))*2^-(x*10)
            endKlang.SetAmplitudenFunktion(x => (float)Math.Pow(2.0 * x, 1.0 / 6.0) * (float)Math.Pow(2.0, -(10 * x)));
            endKlang.AddSin(new float[6, 2] { {1f, 0.3f} , 
                                              {2f, 0.3f} , 
                                              {3f, 0.3f} , 
                                              {4f, 0.3f} , 
                                              {5f, 0.3f} , 
                                              {6f, 0.3f} });

            //Überblenden startKlang zu endKlang
            AddKlang(startKlang, x => (1 - 5 * x) / 2 * x > 0 ? (1 - 5 * x)/2 : 0);
            AddKlang(endKlang, x => (5 * x) / 2 < 1 ? (5 * x)/2 : 1);
        }
    }
}
