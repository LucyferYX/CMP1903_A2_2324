using CMP1903_A2_2324;
using System;
using System.Collections;
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

            Statistics stats = new();
            Game? game = null;

            ConsoleKeyInfo keyInfo;

            while (continueProgram) {
                Console.WriteLine("\nWho will be Player 2? Press:\n[1] for real player \n[2] for computer");
                bool valid = false;
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

                Player playerOne = new() { Name = "Player 1", Score = 0, IsComputer = false };
                Player playerTwo = new() { Name = "Player 2", Score = 0, IsComputer = isComputer };

                Console.WriteLine("\nWhich game to play? Press:\n[1] for Sevens Out \n[2] for Three or More");
                valid = false;
                while (!valid) {
                    keyInfo = Console.ReadKey(intercept: true);
                    switch (keyInfo.Key) {
                        case ConsoleKey.D1:
                            valid = true;
                            game = new SevensOut(playerOne, playerTwo);
                            break;
                        case ConsoleKey.D2:
                            valid = true;
                            game = new ThreeOrMore(playerOne, playerTwo);
                            break;
                        default:
                            WriteInvalidInputLine();
                            break;
                    }
                }

                /*                SevensOut sevensOut = new(playerOne, playerTwo);
                                ThreeOrMore threeOrMore = new(playerOne, playerTwo);*/

                bool continueGame = true;
                while (continueGame) {
                    try {
                        game.Play();
                        stats.UpdateStats(game);
                        Console.WriteLine($"\n{game.PlayerOne.Name} score: {game.PlayerOne.Score}");
                        Console.WriteLine($"{game.PlayerTwo.Name} score: {game.PlayerTwo.Score}");
                    } catch (NullReferenceException) {
                        Console.WriteLine("No game has been selected.");
                        break;
                    } catch (Exception ex) {
                        Console.WriteLine($"Error: {ex}");
                        break;
                    }

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
                Console.WriteLine($"Total number of plays: {stats.GetNumberOfPlays("SevensOut") + stats.GetNumberOfPlays("ThreeOrMore")}");

                Console.WriteLine($"\nSevens Out:");
                Console.WriteLine($"Number of SevensOut plays: {stats.GetNumberOfPlays("SevensOut")}");
                Console.WriteLine($"Player One High Score: {stats.GetHighScore("SevensOut", 1)}");
                Console.WriteLine($"Player Two High Score: {stats.GetHighScore("SevensOut", 2)}");

                Console.WriteLine($"\nThree or More:");
                Console.WriteLine($"Number of ThreeOrMore plays: {stats.GetNumberOfPlays("ThreeOrMore")}");
                Console.WriteLine($"Player One High Score: {stats.GetHighScore("ThreeOrMore", 1)}");
                Console.WriteLine($"Player Two High Score: {stats.GetHighScore("ThreeOrMore", 2)}");
            }

            Console.WriteLine($"\nPress any key to exit...");
            _ = Console.ReadKey(true);
        }

/*        public static void WriteStatistics() {
            Console.WriteLine($"\nStatistics!");
            Console.WriteLine($"Sevens Out:");
            Console.WriteLine($"Number of Plays: {stats.NumberOfPlays}");
            Console.WriteLine($"Player One High Score: {stats.GetHighScore("SevensOut", 1)}");
            Console.WriteLine($"Player Two High Score: {stats.GetHighScore("SevensOut", 2)}");
        }*/

        public static void WriteInvalidInputLine() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Try again.");
            Console.ResetColor();
        }
    }
}
