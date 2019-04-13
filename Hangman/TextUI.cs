using System;
using System.Linq;

namespace Hangman
{
    public class TextUI
    {
        public string GetTextResponse()
        {
            string text;
            do
            {
                /*
                this.PrintBlankLine();
                this.Print("Please enter a word");
                */
                text = this.GetResponse();
            } while (!text.All(char.IsLetter) || text.All(char.IsWhiteSpace));

            return text.ToLower();
        }

        public string GetCharResponse()
        {
            string text;
            do
            {
                /*
                this.PrintBlankLine();
                this.Print("Please enter a letter");
                */
                text = this.GetResponse();
            } while (!text.All(char.IsLetter) || text.All(char.IsWhiteSpace) || text.ToCharArray().Length > 1);

            return text.ToLower();
        }

        public int GetNumericResponse(int minSelection, int maxSelection)
        {
            int selection;
            do
            {
                /*
                this.PrintBlankLine();
                this.Print("Please enter a number");
                */
            } while (!int.TryParse(this.GetResponse(), out selection) || !(selection >= minSelection && selection <= maxSelection));

            return selection;
        }

        public string GetResponse()
        {
            return Console.ReadLine();
        }

        public void AwaitResponse()
        {
            Console.ReadKey();
        }

        public void ChangeTextColour(ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
        }

        public void ResetTextColour()
        {
            Console.ResetColor();
        }

        public void PrintConsoleTitle(string text)
        {
            Console.Title = text;
        }

        public void Print(string display)
        {
            Console.WriteLine(display);
        }

        public void PrintCenter(string display)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (display.Length / 2)) + "}", display));
        }

        public void PrintBlankLine()
        {
            Console.Write(Environment.NewLine);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
