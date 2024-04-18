using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
Three or More
5 x dice
Rules:
	Roll all 5 dice hoping for a 3-of-a-kind or better.
	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	3-of-a-kind: 3 points
	4-of-a-kind: 6 points
	5-of-a-kind: 12 points
    First to a total of 20.
*/

namespace CMP1903_A2_2324 {
    public class ThreeOrMore(IPlayer playerOne, IPlayer playerTwo) : Game(5, playerOne, playerTwo) {
        private const int DieCount = 5;
        private const int EndScore = 20;
        /// <summary>
        /// Method that continues the game until one of the players scores 20 or more.
        /// </summary>
        public override void Play() {
            Reset();

            while (PlayerOne.Score < EndScore && PlayerTwo.Score < EndScore) {
                if (PlayTurn(PlayerOne, $"\n{PlayerOne.Name} turn. Press any key to roll the dice...", $"{PlayerOne.Name} rolled ")) {
                    break;
                }

                if (PlayTurn(PlayerTwo, PlayerTwo.IsComputer ? $"\n{PlayerTwo.Name} turn." : $"\n{PlayerTwo.Name} turn. Press any key to roll the dice...", PlayerTwo.IsComputer ? $"{PlayerTwo.Name} rolled " : $"{PlayerTwo.Name} rolled ")) {
                    break;
                }
            }
        }

        /// <summary>
        /// Method that lets a player play a single turn in the game.
        /// </summary>
        /// <param name="player">The player with current turn.</param>
        /// <param name="turnMessage">The message to display at the start of the turn.</param>
        /// <param name="rollMessage">The message to display after the dice are rolled.</param>
        /// <returns>Returns true if the player's score is 20 or more, returns false otherwise.</returns>
        private bool PlayTurn(IPlayer player, string turnMessage, string rollMessage) {
            Console.WriteLine(turnMessage);
            if (!player.IsComputer) {
                Console.ReadKey(true);
            }
            int[] rolls = RollDice();
            Console.WriteLine($"{rollMessage}{string.Join(", ", rolls)}");
            if (!player.IsComputer) {
                rolls = HandleTwoOfAKind(rolls, player);
            }
            player.Score += CalculateScore(rolls);
            Console.WriteLine($"{player.Name} score is {player.Score}");

            return player.Score >= EndScore;
        }

        /// <summary>
        /// Method that handles the scenario when a player rolls two of a kind, where the player is given the option to re-roll all the dice or only the remaining dice.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <param name="player">The player who rolled the dice.</param>
        /// <returns>The new array of dice rolls after handling the two of a kind.</returns>
        private int[] HandleTwoOfAKind(int[] rolls, IPlayer player) {
            var counts = new int[DieCount+1];
            foreach (var roll in rolls) {
                counts[roll - 1]++;
            }

            for (int i = 0; i < counts.Length; i++) {
                if (counts[i] == 2 && !counts.Any(count => count > 2)) {
                    Console.WriteLine($"{player.Name} rolled 2-of-a-kind of {i + 1}! Press: \n [1] to re-roll all dice \n [2] to re-roll the remaining dice");
                    var keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.D1) {
                        rolls = RollDice(DieCount);  // Re-roll all dice
                    } else if (keyInfo.Key == ConsoleKey.D2) {
                        int[] newRolls = new int[DieCount];
                        int count = 0;
                        for (int j = 0; j < rolls.Length; j++) {
                            if (rolls[j] == i + 1 && count < 2) {
                                newRolls[j] = rolls[j];
                                count++;
                            } else {
                                newRolls[j] = RollDice(1)[0];  // Re-roll the dice
                            }
                        }
                        rolls = newRolls;
                    }
                    Console.WriteLine($"New rolls are {string.Join(", ", rolls)}");
                    break;
                }
            }

            return rolls;
        }

        /// <summary>
        /// Method that rolls a specified number of dice.
        /// </summary>
        /// <param name="count">The number of dice to roll. Currently is 5.</param>
        /// <returns>The array of the dice rolls.</returns>
        private int[] RollDice(int count = DieCount) {
            return dice.Take(count).Select(d => d.Roll()).ToArray();
        }

        /// <summary>
        /// Method that calculates the score for a set of dice rolls according to the rules of the game.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <returns>The score for the dice rolls.</returns>
        private static int CalculateScore(int[] rolls) {
            var counts = new int[DieCount+1];
            foreach (var roll in rolls) {
                counts[roll - 1]++;
            }

            for (int i = 0; i < counts.Length; i++) {
                if (counts[i] >= 3) {
                    return counts[i] == 5 ? 12 : counts[i] == 4 ? 6 : 3;
                }
            }

            return 0;
        }
    }
}
