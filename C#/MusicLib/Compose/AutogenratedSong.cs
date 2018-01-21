using SoundGenerator.Wave;
using System;
using System.Collections.Generic;

namespace SoundGenerator.Compose
{
    public class AutogenratedSong
    {
        Random rnd = new Random();
        List<Tone> TonList { set; get; } = new List<Tone>();
        IInstrument instrument = new Piano();

        List<Bar> taktList = new List<Bar>();
        List<Spur> stimmenList = new List<Spur>();

        IBuilder builder;

        public int SchlaegeProTakt { set; get; } = 4;
        public double Speed { set; get; } = 120;
        public int AnzahlTakte { set; get; } = 12;
        public int GruppenGroesse { set; get; } = 4;
        public int AnzahlTeile { set; get; } = 3;
        public KeyType Tonart { set; get; } = KeyType.DurA;

        public void SetBuilder(IBuilder builder)
        {
            this.builder = builder;
        }

        public void Build(String filename)
        {
            builder.Build(TonList, filename);
        }

        public AutogenratedSong(SongOption songOption)
        {
            if (songOption.isTrack1Enabled)
            {
                Spur stimme1 = new BluesImpro(instrument, rnd, 0);
                stimmenList.Add(stimme1);
            }

            if (songOption.isTrack2Enabled)
            {
                Spur stimme2 = new BluesImpro(instrument, rnd, -1);
                stimmenList.Add(stimme2);
            }

            if (songOption.isTrack3Enabled)
            {
                Spur bass1 = new AlternateBass(instrument, rnd);
                stimmenList.Add(bass1);
            }
        }

        public AutogenratedSong()
        {
            Spur stimme1 = new BluesImpro(instrument, rnd, 0);
            Spur stimme2 = new BluesImpro(instrument, rnd, -1);
            Spur bass1 = new AlternateBass(instrument, rnd);

            stimmenList.Add(stimme1);
            stimmenList.Add(stimme2);
            stimmenList.Add(bass1);
        }

        public void Generate()
        {
            for (int i = 0; i < AnzahlTakte; i++)
            {
                Bar takt = new Bar(Tonart);
                taktList.Add(takt);
            }

            int anzahlTakteGrouped = AnzahlTakte - AnzahlTakte % GruppenGroesse;

            int teil = 0;

            int taktIndex = 0;
            int nrInGruppe = 0;
            foreach(Bar currentTakt in taktList)
            {
                currentTakt.NrInGruppe = nrInGruppe;

                nrInGruppe++;
                taktIndex++;

                if ((taktIndex) % GruppenGroesse == 0)
                {
                    teil = (teil + 1) % AnzahlTeile;
                    nrInGruppe = 0;
                }
            }

            AkkordeFestlegenBlues();

            double schlagdauer = 60.0 / Speed;

            foreach (Spur currentSpur in stimmenList)
            {
                List<Tone> melodie = currentSpur.GetMelodie(taktList, schlagdauer, SchlaegeProTakt);
                TonList.AddRange(melodie);
            }

        }

        private void AkkordeFestlegenBlues()
        {
            if (AnzahlTakte % 12 != 0) throw new Exception("Anzahl Takte muss 12-Teilig sein!");
            if (GruppenGroesse != 4) throw new Exception("GruppenGroesse muss 4 sein!");
            if (AnzahlTeile != 3) throw new Exception("Anzahl Teile muss 3 sein!");
            if (SchlaegeProTakt != 4) throw new Exception("SchlaegeProTakt muss 4 sein!");

            for (int i = 0; i < AnzahlTakte; i++)
            {
                taktList[i].Stufe = ChordSequence.BluesStufen[i % 12];
            }
        }
    }
}
