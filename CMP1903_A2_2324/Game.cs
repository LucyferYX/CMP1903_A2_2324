using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMP1903_A1_2324 {
    internal class Game {
        static void Main(string[] args) {
            ConsoleKeyInfo keyInfo;

            Console.WriteLine("\nWhich game to play? Press:\n[1] for Sevens Out \n[2] for Three or More");
            bool valid = false;
            while (!valid) {
                keyInfo = Console.ReadKey(intercept: true);
                switch (keyInfo.Key) {
                    case ConsoleKey.D1:
                        valid = true;
                        //
                        break;
                    case ConsoleKey.D2:
                        valid = true;
                        //
                        break;
                    default:
                        WriteInvalidInputLine();
                        break;
                }
            }

            Console.WriteLine("\nWhat way to play? Press:\n[1] for playing against real player \n[2] for playing against computer");
            valid = false;
            while (!valid) {
                keyInfo = Console.ReadKey(intercept: true);
                switch (keyInfo.Key) {
                    case ConsoleKey.D1:
                        valid = true;
                        //
                        break;
                    case ConsoleKey.D2:
                        valid = true;
                        //
                        break;
                    default:
                        WriteInvalidInputLine();
                        break;
                }
            }

            Console.WriteLine("End.");
        }

        public static void WriteInvalidInputLine() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Try again.");
            Console.ResetColor();
        }
    }
}
