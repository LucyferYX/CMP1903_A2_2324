using CMP1903_A2_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMP1903_A1_2324 {
    internal class Menu {
        static void Main(string[] args) {
            bool continueProgram = true;
            bool isComputer = true;

            Player playerOne = new() { Name = "Player 1", Score = 0, IsComputer = false };
            Player playerTwo = new() { Name = "Player 2", Score = 0, IsComputer = isComputer };

            SevensOut sevensOut = new(playerOne, playerTwo);
            Statistics stats = new();

            ConsoleKeyInfo keyInfo;

            while (continueProgram) {
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

                Console.WriteLine("\nWho will be Player 2? Press:\n[1] for real player \n[2] for computer");
                valid = false;
                while (!valid) {
                    keyInfo = Console.ReadKey(intercept: true);
                    switch (keyInfo.Key) {
                        case ConsoleKey.D1:
                            valid = true;
                            isComputer = false;
                            break;
                        case ConsoleKey.D2:
                            valid = true;
                            isComputer = true;
                            break;
                        default:
                            WriteInvalidInputLine();
                            break;
                    }
                }

                bool continueGame = true;
                while (continueGame) {
                    sevensOut.Play();
                    stats.UpdateStats(sevensOut);
                    Console.WriteLine($"\nPlayer Score: {sevensOut.PlayerOne.Score}");
                    Console.WriteLine($"Computer Score: {sevensOut.PlayerTwo.Score}");

                    Console.WriteLine($"\nContinue? Press:\n[1] to continue this game \n[2] to play different game \n[3] to exit");
                    valid = false;
                    while (!valid) {
                        keyInfo = Console.ReadKey(intercept: true);
                        switch (keyInfo.Key) {
                            case ConsoleKey.D1:
                                valid = true;
                                continueGame = true;
                                break;
                            case ConsoleKey.D2:
                                valid = true;
                                continueGame = false;
                                break;
                            case ConsoleKey.D3:
                                valid = true;
                                continueGame = false;
                                continueProgram = false;
                                break;
                            default:
                                WriteInvalidInputLine();
                                break;
                        }
                    }
                }

                Console.WriteLine($"\nStatistics!");
                Console.WriteLine($"Sevens Out:");
                Console.WriteLine($"Number of Plays: {stats.NumberOfPlays}");
                Console.WriteLine($"Player One High Score: {stats.GetHighScore("SevensOut", 1)}");
                Console.WriteLine($"Player Two High Score: {stats.GetHighScore("SevensOut", 2)}");
            }

            Console.WriteLine($"\nPress any key to exit...");
            _ = Console.ReadKey(true);
        }

        public static void WriteInvalidInputLine() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Try again.");
            Console.ResetColor();
        }
    }
}
