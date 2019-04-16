using System;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class GameManager
    {
        private readonly string title = "Hangman";
        private readonly string version = "Version 1.0.1";
        private readonly string release = "16/April/2019";
        private readonly string contact = "www.github.com/aleuts";

        private StringBuilder wordMask;
        private StringBuilder misses;
        private TextUI textUI;
        private int turns = 10;
        private char[] secretWord;
        private char letterGussed;
        private char mask = Convert.ToChar("?");

        public GameManager()
        {
            this.textUI = new TextUI();
            this.textUI.PrintConsoleTitle($"{this.title} - {this.version}");
            this.GameStart();
        }

        private void PrintHeader()
        {
            this.textUI.PrintBlankLine();
            this.textUI.ChangeTextColour(ConsoleColor.Cyan);
            this.textUI.PrintCenter(this.title);
            this.textUI.ChangeTextColour(ConsoleColor.White);
            this.textUI.PrintCenter(this.version);
            this.textUI.PrintCenter(this.release);
            this.textUI.PrintCenter(this.contact);
            this.textUI.PrintCenter($"+ {new string('-', Console.WindowWidth / 2)} +");
            this.textUI.ResetTextColour();
            this.textUI.PrintBlankLine();
        }

        private void PrintStatus()
        {
            this.textUI.PrintCenter($"Turns: {this.turns} | Word: {this.wordMask.ToString()} | Misses: {this.misses.ToString()}");
        }

        private void GameStart()
        {
            this.misses = new StringBuilder();
            this.SetSecretWord();
            this.MaskSecretWord();
            do
            {
                this.textUI.ClearScreen();
                this.PrintHeader();
                this.PrintStatus();
                this.GetGuess();
                this.CheckGuess();
            } while (this.CheckRemainingTurns() && this.CheckForMatch());
            this.textUI.AwaitResponse();
        }

        private void SetSecretWord()
        {
            this.textUI.PrintBlankLine();
            this.textUI.PrintCenter("Enter a word!");
            this.secretWord = this.textUI.GetTextResponse().ToCharArray();
            this.textUI.ClearScreen();
        }

        // Sets a mask to hide the secret word entered by the puzzle setter.
        private void MaskSecretWord()
        {
            this.wordMask = new StringBuilder(this.secretWord.Length);
            this.wordMask.Append(this.mask, this.secretWord.Length);
        }

        private void GetGuess()
        {
            this.textUI.PrintBlankLine();
            this.textUI.PrintCenter("Make a guess!");
            this.letterGussed = this.textUI.GetCharResponse();
        }

        private void CheckGuess()
        {
            // Check if the letter guessed is contained within the secret word.
            if (this.secretWord.Contains(this.letterGussed))
            {
                // Remove the mask letter to reveal the correct letter guessed of the secret word.
                int index = 0;
                foreach (char letter in this.secretWord)
                {                    
                    if (letter.Equals(this.letterGussed))
                    {
                        this.wordMask.Remove(index, 1);
                        this.wordMask.Insert(index, this.letterGussed);
                    }

                    index++;
                }
            }

            // Check if the letter guessed has been guessed on a previous turn.
            else if (this.misses.ToString().Contains(this.letterGussed))
            {
                // Do nothing
            }

            // If none of the above, assume the guess is incorrect and add the incorrect guess to the misses string.
            else
            {
                this.misses.Append($"{this.letterGussed}, ");
                this.turns--;
            }
        }

        private bool CheckForMatch()
        {
            // Check if the secret word has been revealed, if so the guesser has won.
            if (!this.wordMask.ToString().Contains(this.mask))
            {
                this.GameOver(ConsoleColor.Green, "You Win!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckRemainingTurns()
        {
            // Check if the guesser is out of turns, if so the puzzle setter has won.
            if (this.turns == 0)
            {
                this.GameOver(ConsoleColor.Red, "You Lose!");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Display game over message in a font colour of choice.
        private void GameOver(ConsoleColor colour, string gameOverText)
        {
            this.textUI.ClearScreen();
            this.PrintHeader();
            this.PrintStatus();
            this.textUI.ChangeTextColour(colour);
            this.textUI.PrintBlankLine();
            this.textUI.PrintCenter(gameOverText);
        }
    }
}
