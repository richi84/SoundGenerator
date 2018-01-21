using SoundGenerator.Compose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundGenerator.Wave
{
    public delegate void ProgressChangedEventHandler(Double value);

    public interface IBuilder
    {
        void Build(List<Tone> toene, String filename);
        event ProgressChangedEventHandler ProgressChanged;
        double GetProgressState();
    }
}
