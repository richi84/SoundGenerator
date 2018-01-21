using SoundGenerator.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundGenerator.Compose
{
    public class BluesImpro : Spur
    {
        bool inside = false;
        int zusatz = 0;

        public BluesImpro(IInstrument instrument, Random rnd, int oktavIndexStart) 
            : base(instrument, rnd)
        {
            zusatz = oktavIndexStart;
        }

        public override List<Tone> GetMelodie(List<Bar> taktList, double schlaglaenge, int schlaegeProTakt)
        {
            return taktList.SelectMany(x =>
                GetBarEntries(x, taktList.IndexOf(x), schlaglaenge, schlaegeProTakt)
            ).ToList();
        }

        public List<Tone> GetBarEntries(Bar takt, int taktIndex, double schlaglaenge, int schlaegeProTakt)
        {
            bool dur = (int)takt.KeyType < 15;
            int tonartOffset = Keyboard.GetGrundtonOffset(takt.KeyType);
            int stufenOffset = ChordHelper.GetStufenOffset(dur, takt.Stufe);
            int oktavenOffset = 4 * 12;

            int[] akkordOffsetList = ChordHelper.BluesScale();

            List<Tone> tonList = new List<Tone>();

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                int nr = 0;

                if (rnd.Next(8) == 0 || inside)
                {
                    inside = true;
                    if (rnd.Next(3) == 0) inside = false;

                    int start = rnd.Next(akkordOffsetList.Count());
                    bool aufwaerts = rnd.Next(2) == 0;

                    for (int x = 0; x < 3; x++)
                    {
                        nr = tonartOffset + stufenOffset + akkordOffsetList[start] + oktavenOffset + zusatz*12;

                        tonList.Add(
                                    new Tone(
                                        (taktIndex * schlaegeProTakt) * schlaglaenge + index / 3.0 * schlaglaenge,
                                        (taktIndex * schlaegeProTakt) * schlaglaenge + (index + 3) / 3.0 * schlaglaenge,
                                        nr,
                                        Instrument
                                    )
                                );

                        index += 1;

                        if(aufwaerts)
                        {
                            start++;

                            if(start >= akkordOffsetList.Count())
                            {
                                start -= akkordOffsetList.Count();
                                zusatz ++;
                                if (zusatz > 0) zusatz = 1;
                            }
                        }
                        else
                        {
                            start--;
                            if (start < 0)
                            {
                                start += akkordOffsetList.Count();
                                zusatz --;
                                if (zusatz < -1) zusatz = -1;
                            }
                        }
                    }
                }
                else
                {
                    if (rnd.Next(5) != 0)
                    {
                        nr = tonartOffset + stufenOffset + akkordOffsetList[rnd.Next(akkordOffsetList.Count())] + oktavenOffset + zusatz * 12;
                        tonList.Add(
                                new Tone(
                                    (taktIndex * schlaegeProTakt) * schlaglaenge + index / 3.0 * schlaglaenge,
                                    (taktIndex * schlaegeProTakt) * schlaglaenge + (index + 6) / 3.0 * schlaglaenge,
                                    nr,
                                    Instrument
                                )
                            );
                    }

                    index += 2;

                    nr = tonartOffset + stufenOffset + akkordOffsetList[rnd.Next(akkordOffsetList.Count())] + oktavenOffset + zusatz * 12;
                    tonList.Add(
                                new Tone(
                                    (taktIndex * schlaegeProTakt) * schlaglaenge + index / 3.0 * schlaglaenge,
                                    (taktIndex * schlaegeProTakt) * schlaglaenge + (index + 3) / 3.0 * schlaglaenge,
                                    nr,
                                    Instrument
                                )
                            );

                    index += 1;
                }

            }

            return tonList;
        }
    }
}