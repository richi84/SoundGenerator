using SoundGenerator.Compose;
using SoundGenerator.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService
{
    class BuilderTask
    {
        public bool IsFinished { set; get; }
        public int ID { set; get; }
        public String FilePath { set; get; }
        IBuilder builder;

        private void BildSong(SongOption songOption)
        {
            //Generate the melody
            AutogenratedSong song = new AutogenratedSong(songOption);
            song.Generate();

            //Create wave file builder and register event for progressbar
            builder = new WaveFileBuilder();

            //Dependency Injection (Setter Injection)
            song.SetBuilder(builder);

            //Generate the wave file
            song.Build(Path.Combine(FilePath, ID.ToString()+".wav"));
        }

        public void Build(SongOption songOption)
        {
            Task.Run(() =>
                {
                    BildSong(songOption);
                    IsFinished = true;
                    builder = null;

                    Console.WriteLine("Finished build: " + ID);
                });
        }

        public double GetProgressState()
        {
            if (IsFinished) return 100;
            if (builder != null) return builder.GetProgressState();
            else return 0;
        }
            
    }
}
