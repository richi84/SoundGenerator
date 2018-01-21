using SoundGenerator.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundGenerator.Compose
{
    public class AlternateBass : Spur
    {
        public AlternateBass(IInstrument instrument, Random rnd) : base(instrument, rnd)
        {
        }

        public override List<Tone> GetMelodie(List<Bar> taktList, double schlaglaenge, int schlaegeProTakt)
        {
            return taktList.SelectMany(x =>
                {
                    int genSchlaege = schlaegeProTakt;

                    if (x == taktList.Last())
                        genSchlaege = 3;

                    List<Tone> tonList = new List<Tone>();
                    for(int i=0; i < genSchlaege; i++)
                    {
                        tonList.Add(
                                new Tone(
                                    (taktList.IndexOf(x) * schlaegeProTakt + i) * schlaglaenge, 
                                    (taktList.IndexOf(x) * schlaegeProTakt + i + 2) * schlaglaenge, 
                                    GetNextTonNr(x, i), Instrument
                                )
                            );
                    }

                    return tonList;
                }).ToList();
        }

        public int GetNextTonNr(Bar takt, int schlagNr)
        {
            bool dur = (int)takt.KeyType < 15;
            int tonartOffset = Keyboard.GetGrundtonOffset(takt.KeyType);
            int stufenOffset = ChordHelper.GetStufenOffset(dur, takt.Stufe);
            int oktavenOffset = 24;
          
            int[] TriadOffsetList=null;

            ToneSequence akkordTyp = ChordHelper.GetScaleStepChordTyp(dur, takt.Stufe);

            switch(akkordTyp)
            {
                case ToneSequence.MajorTriad:
                    TriadOffsetList = ChordHelper.DurTriad();
                    break;
                case ToneSequence.MinerTriad:
                    TriadOffsetList = ChordHelper.MollTriad();
                    break;
                case ToneSequence.Major7thChord:
                    TriadOffsetList = ChordHelper.Major7thTriad();
                    break;
            }

            return tonartOffset + stufenOffset + TriadOffsetList[schlagNr % 2 * 2] - schlagNr % 2 * 12 + oktavenOffset;

        }
    }
}