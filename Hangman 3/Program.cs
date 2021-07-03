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
            var secretWord = new List<string> { "one", "two", "three", "four" };
            foreach (string word in secretWord)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
            var random = new Random();
            int index = random.Next(secretWord.Count);
            string chosenWord = secretWord[index];
            //Console.WriteLine(secretWord[index]);
            //Console.ReadLine();
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
                Console.WriteLine("Enter A Guess: ");
                letterGuess = char.Parse(Console.ReadLine());
                //Console.WriteLine(letterGuess);
                //Console.ReadLine();

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
                    if ( currentWord == chosenWord)
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
                        Console.WriteLine("Boo!");
                        remainingGuesses -= 1;
                        Console.WriteLine($"Remaining Guesses: {remainingGuesses}");
                        Console.WriteLine($"Guessed Letters: {guessedLetters}");
                        if (remainingGuesses == 0)
                        {
                            Console.WriteLine("You've run out of guesses. Too bad!");
                            Console.ReadLine();
                            isGameRunning = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've already guessed that letter.");
                    }
                    
                }
                //Console.ReadLine();
            }
            


        }
    }
}
