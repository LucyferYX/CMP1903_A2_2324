using CMP1903_A1_2324;
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
        /// <summary>
        /// Amount of die that will be rolled by a single player in one turn.
        /// </summary>
        private const int DieCount = 5;
        /// <summary>
        /// The score at which the ThreeOrMore game ends.
        /// </summary>
        private const int EndScore = 20;

        /// <summary>
        /// Method that starts and continues the game until one of the players scores 20 or more.
        /// </summary>
        public override void Play() {
            Reset();

            while (PlayerOne.Score < EndScore && PlayerTwo.Score < EndScore) {
                if (PlayTurn(PlayerOne)) {
                    break;
                }

                if (PlayTurn(PlayerTwo)) {
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
        private bool PlayTurn(IPlayer player) {
            WriteTurnMessage(player);

            if (!player.IsComputer) {
                Console.ReadKey(true);
            }

            int[] rolls = RollDice(DieCount);
            WriteRollMessage(player, rolls, false);

            rolls = HandleTwoOfAKind(rolls, player);
            TestScore(player, rolls);

            WriteScoreMessage(player);

            return player.Score >= EndScore;
        }

        /// <summary>
        /// Method that handles the scenario when a player rolls two of a kind, where the player is given the option to re-roll all the dice or only the remaining dice.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <param name="player">The player who rolled the dice.</param>
        /// <returns>The new array of dice rolls after handling the two of a kind.</returns>
        private int[] HandleTwoOfAKind(int[] rolls, IPlayer player) {
            var counts = GetRollCounts(rolls);

            for (int i = 0; i < counts.Length; i++) {
                if (counts[i] == 2 && !counts.Any(count => count > 2)) {
                    rolls = HandlePlayer(rolls, player, i);
                    WriteRollMessage(player, rolls, true);
                    break;
                }
            }

            return rolls;
        }

        /// <summary>
        /// Method that handles the player's turn when two of a kind are rolled.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <param name="player">The player with current turn.</param>
        /// <param name="i">The index of the two of a kind die.</param>
        /// <returns>The new array of dice rolls after handling the two of a kind.</returns>
        private int[] HandlePlayer(int[] rolls, IPlayer player, int i) {
            int choice;

            if (player.IsComputer) {
                Random rnd = new();
                choice = rnd.Next(1, 4);
            } else {
                WriteRerollChoiceMessage(player, i);
                var keyInfo = Console.ReadKey(intercept: true);
                choice = keyInfo.Key == ConsoleKey.D1 ? 1 : keyInfo.Key == ConsoleKey.D2 ? 2 : 3;
            }

            switch (choice) {
                case 1:
                    OutputRollChoiceMessage(player, 1);
                    rolls = RollDice(DieCount);
                    break;
                case 2:
                    OutputRollChoiceMessage(player, 2);
                    rolls = RollDice(DieCount, rolls, i);
                    break;
                default:
                    OutputRollChoiceMessage(player, 0);
                    break;
            }

            return rolls;
        }

        /// <summary>
        /// Method that counts instance of each roll.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <returns>The array that shows how many times each die roll appears. The value at each index is the count of the die roll.</returns>
        private static int[] GetRollCounts(int[] rolls) {
            var counts = new int[DieCount + 1];

            foreach (var roll in rolls) {
                counts[roll - 1]++;
            }

            return counts;
        }

        /// <summary>
        /// Method that calculates the score for a set of dice rolls according to the rules of the game.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <returns>The score for the dice rolls.</returns>
        private static int CalculateScore(int[] rolls) {
            try {
                var counts = new int[DieCount + 1];

                foreach (var roll in rolls) {
                    counts[roll - 1]++;
                }

                for (int i = 0; i < counts.Length; i++) {
                    if (counts[i] >= 3) {
                        return counts[i] == 5 ? 12 : counts[i] == 4 ? 6 : 3;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}. Score could not be calculated.");
            }

            return 0;
        }

        /// <summary>
        /// Method that calculates the expected score, adds it to player and verifies if the player's score is set and added correctly.
        /// </summary>
        /// <param name="player">The player whose score is to be verified.</param>
        /// <param name="rolls">The array of dice rolls.</param>
        private static void TestScore(IPlayer player, int[] rolls) {
            try {
                int expectedScore = player.Score + CalculateScore(rolls);
                player.Score += CalculateScore(rolls);
                Testing.TestingThreeOrMoreTotalSum(player, expectedScore);
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}. Score couldn't be tested.");
            }
        }

        /// <summary>
        /// Method that outputs line about player's rolls.
        /// </summary>
        /// <param name="player">The current player.</param>
        /// <param name="rolls">The array of player's die rolls.</param>
        /// <param name="final">True if the rolls are after the re-roll.</param>
        public static void WriteRollMessage(IPlayer player, int[] rolls, bool final) {
            Console.WriteLine(!final ? $"{player.Name} rolled {string.Join(", ", rolls)}" : $"Final rolls are {string.Join(", ", rolls)}");
        }

        /// <summary>
        /// Method that outputs line about player's possible choice on re-roll.
        /// </summary>
        /// <param name="player">The current player.</param>
        /// <param name="i">The index of the two of a kind die.</param>
        public static void WriteRerollChoiceMessage(IPlayer player, int i) {
            Console.WriteLine($"{player.Name} rolled 2-of-a-kind of {i + 1}! Press: \n [1] to re-roll all dice \n [2] to re-roll the remaining dice \n Any other key to skip re-roll");
        }

        /// <summary>
        /// Method that outputs line about player's chosen choice on re-roll.
        /// </summary>
        /// <param name="player">The current player.</param>
        /// <param name="choice">The player's choice on what to do.</param>
        private static void OutputRollChoiceMessage(IPlayer player, int choice) {
            switch (choice) {
                case 1:
                    Console.WriteLine($"{player.Name} chose to re-roll all dice");
                    break;
                case 2:
                    Console.WriteLine($"{player.Name} chose to re-roll the remaining dice");
                    break;
                default:
                    Console.WriteLine($"{player.Name} chose to skip re-roll");
                    break;
            }
        }

    }
}
