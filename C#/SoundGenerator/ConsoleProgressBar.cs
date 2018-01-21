using System;

namespace SoundGenerator
{
    public class ConsoleProgressBar
    {
        int startX = 0;
        int startY = 0;

        public void Init()
        {
            //Save the current cursor location
            startX = Console.CursorLeft;
            startY = Console.CursorTop;
        }

        public void Update(double percent)
        {
            //Update the progressbar at the saved cursor position
            ShowString(BuildBar(percent));
        }

        public String BuildBar(double percent)
        {
            String startBar = "[                              ]";
            String finalBar = "[##############################]";

            //Calculate the number of characters (without boarders)
            int numberOfFinal = (int)((finalBar.Length - 2) * percent * 0.01);

            //Build the bar 
            String output = finalBar.Substring(0, numberOfFinal + 1) + startBar.Substring(numberOfFinal + 1);

            //Add the percentage at the end of the bar
            output += " " + Math.Round(percent, 1).ToString() + "%     ";

            return output;
        }

        public void ShowString(String bar)
        {
            try
            {
                //Set the cursor to the saved location
                Console.SetCursorPosition(startX , startY);
                //Write the generated bar
                Console.Write(bar);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
