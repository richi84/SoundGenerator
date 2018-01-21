using System;
using System.Text;

namespace SoundGenerator.Wave
{
    class Wave
    {
        public static byte[] CreateWave(short[] channel1, short[] channel2)
        {
            //Calculate Size
            int dataLen = channel1.Length * 2 + channel2.Length * 2;

            //CreateHeader
            byte[] header = CreateHeader(dataLen);

            //Create output array and include header
            int totalLen = dataLen + header.Length;
            byte[] dataArray = new byte[totalLen];
            Array.Copy(header, dataArray, header.Length);

            int index = header.Length;

            //Insert channeldata into dataArray
            for (int i = 0; i < channel1.Length; i++)
            {
                byte[] leftSample = BitConverter.GetBytes(channel1[i]);
                byte[] rightSample = BitConverter.GetBytes(channel2[i]);
                Array.Copy(leftSample, 0, dataArray, index, 2);
                index += 2;
                Array.Copy(rightSample, 0, dataArray, index, 2);
                index += 2;
            }

            return dataArray;
        }

        public static byte[] CreateHeader(int length)
        {
            int samplerate = 44100;
            short channels = 2;
            short bitsPerSample = 16;

            int index = 0;
            Byte[] waveheader = new Byte[44];

            //add "RIFF"
            byte[] bytesRiff = Encoding.ASCII.GetBytes("RIFF");
            index = AddToByteArray(bytesRiff, waveheader, index);

            //Length (+36 for part of the header)
            byte[] bytesLengthHeader = BitConverter.GetBytes(length + 36);
            index = AddToByteArray(bytesLengthHeader, waveheader, index);

            //add "WAVEfmt "
            byte[] bytesWave = Encoding.ASCII.GetBytes("WAVEfmt ");
            index = AddToByteArray(bytesWave, waveheader, index);

            //Length fmt header
            byte[] bytesLengthFmt = BitConverter.GetBytes((int)16);
            index = AddToByteArray(bytesLengthFmt, waveheader, index);

            //Format (PCM=1)
            byte[] bytesFormat = BitConverter.GetBytes((short)1);
            index = AddToByteArray(bytesFormat, waveheader, index);

            //Channels (2=Stereo)
            byte[] bytesChannels = BitConverter.GetBytes(channels);
            index = AddToByteArray(bytesChannels, waveheader, index);

            //SampleRate
            byte[] bytesSampleRate = BitConverter.GetBytes(samplerate);
            index = AddToByteArray(bytesSampleRate, waveheader, index);

            //bytes/second
            int bytesPerSecond = samplerate * (bitsPerSample * channels) / 8;
            byte[] bytesBytesPerSecond = BitConverter.GetBytes(bytesPerSecond);
            index = AddToByteArray(bytesBytesPerSecond, waveheader, index);

            //block align
            short blockAlign = (short)(channels * ((bitsPerSample + 7) / 8));
            byte[] bytesBlockAlign = BitConverter.GetBytes(blockAlign);
            index = AddToByteArray(bytesBlockAlign, waveheader, index);

            //bits/sample
            byte[] bytesBitsPerSample = BitConverter.GetBytes(bitsPerSample);
            index = AddToByteArray(bytesBitsPerSample, waveheader, index);

            //add "data"
            byte[] bytesData = Encoding.ASCII.GetBytes("data");
            index = AddToByteArray(bytesData, waveheader, index);

            //Length
            byte[] bytesLength = BitConverter.GetBytes(length);
            index = AddToByteArray(bytesLength, waveheader, index);

            return waveheader;
        }

        public static int AddToByteArray(byte[] bytesToAdd, byte[] bytes, int index)
        {
            int length = bytesToAdd.Length;
            Array.Copy(bytesToAdd, 0, bytes, index, length);
            return length + index;
        }
    }
}
