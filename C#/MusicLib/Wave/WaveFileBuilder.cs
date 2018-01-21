using SoundGenerator.Compose;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoundGenerator.Wave
{
    public class WaveFileBuilder : IBuilder
    {
        double percent;
        int sampleRate = 44100;
        public event ProgressChangedEventHandler ProgressChanged;

        public void Build(List<Tone> toene, String filename)
        {
            if (toene.Count == 0) return;

            double dauer = toene.Max(x => x.ToTime);

            int anzSamples = (int)(dauer * sampleRate);

            short[] channel1 = new short[anzSamples];
            short[] channel2 = new short[anzSamples];

            RaiseProgressChanged(0);

            int index = 0;
            foreach (Tone ton in toene)
            {
                double startTime = ton.FromTime;
                double endTime = ton.ToTime;

                int indexStartSample = (int)(startTime * sampleRate);
                int endStartSample = (int)(endTime * sampleRate)-1;

                int anzSamplesTon1 = endStartSample - indexStartSample + 1;
                int anzSamplesTon2 = endStartSample - indexStartSample + 1;

                short[] values1 = GenerateTon(ton, anzSamplesTon1);
                short[] values2 = GenerateTon(ton, anzSamplesTon2);

                
                for (int i = 0; i < anzSamplesTon1; i++)
                {
                    values1[i] += channel1[i + indexStartSample];
                    values2[i] += channel2[i + indexStartSample];
                }

                Array.Copy(values1, 0, channel1, indexStartSample, anzSamplesTon1);
                Array.Copy(values2, 0, channel2, indexStartSample, anzSamplesTon2);

                index++;
                percent = ((double)index) / toene.Count * 100;
                RaiseProgressChanged(percent);
            }

            RaiseProgressChanged(100);

            byte[] wave = Wave.CreateWave(channel1, channel2);

            File.WriteAllBytes(filename, wave);
        }

        void RaiseProgressChanged(double value)
        {
            ProgressChanged?.Invoke(value);
        }

        private short[] GenerateTon(Tone ton, int anzSamplesTon)
        {
            float dauer = anzSamplesTon / (float)sampleRate;
            short[] samples = new short[anzSamplesTon];

            for (int i = 0; i < anzSamplesTon; i++)
            {
                float t = i / (float)sampleRate;
                float sampleValue = 0;

                sampleValue = ton.Instrument.CalcValue(t / dauer, t, Keyboard.GetFrequenzOfKey(ton.KeyNumber));

                samples[i]=CalcSound(sampleValue);
            }

            return samples;
        }

        short CalcSound(float value)
        {
            if (value > 1) value = 1;
            if (value < -1) value = -1;

            value *= 0.5f;
            return (short)(value * 32767);  
        }

        public double GetProgressState()
        {
            return percent;
        }
    }
}
