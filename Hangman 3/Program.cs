using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int remainingGuesses = 6;
            string guessedLetters = "";
            string[] asciiHangman = new string[7];
            asciiHangman[6] = " +---+ \n" +
                              " |   | \n" +
                              "     | \n" +
                              "     | \n" +
                              "     | \n" +
                              "     | \n" +
                               "=========";

            asciiHangman[5] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              "     | \n" +
                              "     | \n" +
                              "     | \n" +
                              "=========";

            asciiHangman[4] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              " |   | \n" +
                              "     | \n" +
                              "     | \n" +
                              "=========";

            asciiHangman[3] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              "(|   | \n" +
                              "     | \n" +
                              "     | \n" +
                              "=========";

            asciiHangman[2] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              "(|)  | \n" +
                              "     | \n" +
                              "     | \n" +
                              "=========";

            asciiHangman[1] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              "(|)  | \n" +
                              "]    | \n" +
                              "     | \n" +
                              "=========";

            asciiHangman[0] = " +---+ \n" +
                              " |   | \n" +
                              " 0   | \n" +
                              "(|)  | \n" +
                              "] [  | \n" +
                              "     | \n" +
                              "=========";

            
            var secretWord = new List<string> { "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
            "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
            "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE" };
            var random = new Random();
            int index = random.Next(secretWord.Count);
            string chosenWord = secretWord[index];
            Console.WriteLine(secretWord[index]);
            Console.ReadLine();
            string displayWord = "";
            foreach (char letter in chosenWord)
            {
                displayWord += "_ ";
            }
            Console.WriteLine(displayWord.ToString());
            char letterGuess;
            bool isGameRunning = true;
            
            while (isGameRunning) 
            {
                Console.Clear();
                Console.WriteLine(asciiHangman[remainingGuesses]);
                Console.WriteLine(displayWord);
                Console.WriteLine("Enter A Guess: ");
                Console.WriteLine($"Remaining Guesses: {remainingGuesses}");
                Console.WriteLine($"Guessed Letters: {guessedLetters}");
                letterGuess = char.Parse(Console.ReadLine());
                letterGuess = char.ToUpper(letterGuess);
                if (chosenWord.Contains(letterGuess))
                {
                    for (int i = 0; i < chosenWord.Length; i++)
                    {
                        if (chosenWord[i].Equals(letterGuess))
                        {
                            int n = 2 * i;
                            StringBuilder sb = new StringBuilder(displayWord);
                            sb[n] = letterGuess;
                            displayWord = sb.ToString();
                        }
                    }
                    Console.WriteLine(displayWord);
                    string currentWord = displayWord.Replace(" ", "");
                    if (currentWord == chosenWord)
                    {
                        Console.WriteLine("You guessed it! Congratulations!");
                        Console.ReadKey();
                        isGameRunning = false;
                    }
                }
                else
                {
                    if (!guessedLetters.Contains(letterGuess))
                    {
                        guessedLetters += (Char.ToString(letterGuess)) + " ";
                        remainingGuesses -= 1;
                        if (remainingGuesses == 0)
                        {
                            Console.Clear();
                            Console.WriteLine(asciiHangman[remainingGuesses]);
                            Console.WriteLine($"The word was: {chosenWord}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You've run out of guesses. Too bad!");
                            Console.ReadLine();
                            isGameRunning = false;
                        }
                    }
                }
            }
        }
    }
}
