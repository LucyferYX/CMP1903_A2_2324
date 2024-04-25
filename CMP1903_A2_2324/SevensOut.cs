using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Sevens Out
2 x dice
Rules:
	Roll the two dice, noting the total rolled each time.
	If it is a 7 - stop.
	If it is any other number - add it to your total.
	If it is a double - add double the total to your score (3,3 would add 12 to your total)
*/

namespace CMP1903_A2_2324 {
    public class SevensOut(IPlayer playerOne, IPlayer playerTwo) : Game(2, playerOne, playerTwo) {
        /// <summary>
        /// Amount of die that will be rolled by a single player in one turn.
        /// </summary>
        private const int DieCount = 2;
        /// <summary>
        /// The score at which the SevensOut game ends.
        /// </summary>
        private const int EndScore = 7;

        /// <summary>
        /// Method that starts and continues the game until it is true (until a specific value is rolled).
        /// </summary>
        public override void Play() {
            Reset();

            while (true) {
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
        /// <param name="player">The player who is playing the turn.</param>
        /// <param name="turnMessage">The message to display at the start of the turn.</param>
        /// <returns>Returns true if the total roll is same as EndScore, returns false otherwise.</returns>
        public bool PlayTurn(IPlayer player) {
            Console.WriteLine(player.IsComputer ? $"\n{player.Name} turn." : $"\n{player.Name} turn. Press any key to roll the dice...");
            if (!player.IsComputer) {
                Console.ReadKey(true);
            }

            int[] rolls = RollDice(DieCount);
            int total = ProcessRolls(player, rolls);

            TestTotalSum(rolls, total);

            player.Score += total;

            bool isGameOver = total == EndScore;

            TestGameEndCondition(isGameOver, total);

            Console.WriteLine($"{player.Name} score is {player.Score}");

            return isGameOver;
        }

        /// <summary>
        /// Method that calculates and writes a message to the console about the results of the player's dice rolls.
        /// </summary>
        /// <param name="player">The player who rolled the dice.</param>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <returns>The total score of the dice rolls.</returns>
        private static int ProcessRolls(IPlayer player, int[] rolls) {
            int total = rolls.Sum();
            if (rolls[0] == rolls[1]) {
                Console.WriteLine($"{player.Name} rolled {total}! Double points {total * 2}! ({rolls[0]},{rolls[1]})");
                if (rolls[0] == rolls[1]) {
                    total *= 2;
                }
            } else {
                Console.WriteLine($"{player.Name} rolled {total}! ({rolls[0]},{rolls[1]})");
            }

            return total;
        }

        /// <summary>
        /// Method that tests if the total sum of the dice rolls is calculated correctly.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <param name="total">The total sum of the dice rolls returned by the ProcessRolls method.</param>
        private static void TestTotalSum(int[] rolls, int total) {
            int expectedTotal = rolls.Sum();
            if (rolls[0] == rolls[1]) {
                expectedTotal *= 2;
            }
            Testing.TestingSevensOutTotalSum(total, expectedTotal);
        }

        /// <summary>
        /// Method that tests whether the game ends correctly when a player rolls EndScore value.
        /// </summary>
        /// <param name="isGameOver">Boolean that indicates whether the game is over.</param>
        /// <param name="total">The total sum of the dice rolls.</param>
        private static void TestGameEndCondition(bool isGameOver, int total) {
            Testing.TestingSevensOutEndScore(isGameOver, total);
        }

    }
}
