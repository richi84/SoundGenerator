using System;
using SoundGenerator.Compose;
using SoundGenerator.Wave;

namespace SoundGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate the melody
            AutogenratedSong song = new AutogenratedSong();
            song.Generate();

            //Create and initialize progressbar
            ConsoleProgressBar progressBar = new ConsoleProgressBar();
            progressBar.Init();

            //Create wave file builder and register event for progressbar
            IBuilder builder = new WaveFileBuilder();
            builder.ProgressChanged += (percent) => progressBar.Update(percent);

            //Dependency Injection (Setter Injection)
            song.SetBuilder(builder);

            //Generate the wave file
            song.Build(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".wav");

            Console.Write("\r\nFinished!\r\n");
        }
    }
}
