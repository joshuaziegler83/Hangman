using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_3
{
    public class HangmanPoco
    {
        public string BadGuesses { get; set; }
        public int RemainingGuesses { get; set; }
        public string WordToGuess { get; }
        public StringBuilder Blanks { get; }
        public bool Win { get { return WordToGuess == Blanks.ToString(); } }
        public bool Lose { get { return RemainingGuesses == 0; } }
        public bool Valid(char userInput)
        {
            return !(BadGuesses.Contains(Char.ToUpper(userInput)) || Blanks.ToString().Contains(Char.ToUpper(userInput)));
        }

        public HangmanPoco(List<string> wordBank, int remainingGuesses)
        {
            RemainingGuesses = remainingGuesses;
            BadGuesses = "";

            var random = new Random();
            int index = random.Next(wordBank.Count);
            WordToGuess = wordBank[index].ToUpper();

            string blanks = new String('_', WordToGuess.Length);
            Blanks = new StringBuilder(blanks);
        }

        public bool EvaluateGuess(char userInput)
        {
            char guess = Char.ToUpper(userInput);
            if (WordToGuess.Contains(guess))
            {
                for (int i = 0; i < WordToGuess.Length; i++)
                {
                    if (WordToGuess[i] == guess)
                    {
                        Blanks[i] = guess;
                    }
                }
                return true;
            }
            else
            {
                BadGuesses += $"{guess} ";
                RemainingGuesses--;
                return false;
            }
        }
    }

}
