using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_3
{
    public class GameIO
    {
        private static readonly List<string> _wordBank = new List<string>
        { "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
          "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
          "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE" };
        private static readonly int _remainingGuesses = 6;
        private readonly string[] _asciiHangman = {
            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            "/|\\  | \n" +
            "/ \\  | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            "/|\\  | \n" +
            "/     | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            "/|\\  | \n" +
            "     | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            "/|   | \n" +
            "     | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            " |   | \n" +
            "     | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            " 0   | \n" +
            "     | \n" +
            "     | \n" +
            "     | \n" +
            "=========" ,

            " +---+ \n" +
            " |   | \n" +
            "     | \n" +
            "     | \n" +
            "     | \n" +
            "     | \n" +
            "=========" ,
    };
        private readonly HangmanPoco _hangman = new HangmanPoco(_wordBank, _remainingGuesses);

        public void Run()
        {
            if (_hangman.Lose)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            DisplayTop();
            EvaluateUserResponse();
        }
        private void DisplayTop()
        {
            Console.Clear();
            DisplayTitle();
            Console.WriteLine(_asciiHangman[_hangman.RemainingGuesses]);
            DisplayBlanks();
            Console.WriteLine($"Incorrect Guesses: {_hangman.BadGuesses}");
            Console.WriteLine($"Remaining guesses {_hangman.RemainingGuesses}");
        }
        private void EvaluateUserResponse()
        {
            if (_hangman.Win)
            {
                Console.WriteLine("You guessed it! Congratulations!");
                Exit();
            }
            else if (_hangman.Lose)
            {
                Console.WriteLine("You've run out of guesses. Too bad!");
                Console.WriteLine($"The word was: {_hangman.WordToGuess}");
                Exit();
            }
            else
            {
                Console.Write("Enter a guess: ");
                char response = Console.ReadKey().KeyChar;
                if (Char.IsLetter(response) && _hangman.Valid(response))
                    _hangman.EvaluateGuess(response);

                Run();
            }
        }
        private void DisplayTitle()
        {
            Console.WriteLine("██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗");
            Console.WriteLine("██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║");
            Console.WriteLine("███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║");
            Console.WriteLine("██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║");
            Console.WriteLine("██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║");
            Console.WriteLine("╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝");
        }
        private void DisplayBlanks()
        {
            foreach (char blank in _hangman.Blanks.ToString())
            {
                Console.Write(blank.ToString() + ' ');
            }
            Console.Write('\n');
        }
        private void Exit()
        {
            Console.WriteLine("Press Any key to exit!");
            Console.ReadKey();
        }
    }
}