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

        public char GetCharResponse()
        {
            char letter;
            do
            {
                /*
                this.PrintBlankLine();
                this.Print("Please enter a letter");
                */
            } while (!char.TryParse(this.GetResponse(), out letter) || !char.IsLetter(letter) || char.IsWhiteSpace(letter));

            return char.ToLower(letter);
        }

        public int GetNumericResponse(int minNumber, int maxNumber)
        {
            int number;
            do
            {
                /*
                this.PrintBlankLine();
                this.Print("Please enter a number");
                */
            } while (!int.TryParse(this.GetResponse(), out number) || !(number >= minNumber && number <= maxNumber));

            return number;
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
