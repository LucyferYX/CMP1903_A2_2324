using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Sevens Out
2 x dice
Rules:
	Roll the two dice, noting the total rolled each time.
	If it is a 7 - stop.
	If it is any other number - add it to your total.
		If it is a double - add double the total to your score (3,3 would add 12 to your total)*/

namespace CMP1903_A2_2324 {
    public class SevensOut(IPlayer playerOne, IPlayer playerTwo) : Game(2, playerOne, playerTwo) {
        private const int DieCount = 2;
        private const int EndScore = 7;

        /// <summary>
        /// Method that continues the game until it is true (until a specific value is rolled).
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
        /// <returns>Returns true if the total roll is 7, returns false otherwise.</returns>
        private bool PlayTurn(IPlayer player) {
            Console.WriteLine(player.IsComputer ? $"\n{player.Name} turn." : $"\n{player.Name} turn. Press any key to roll the dice...");
            if (!player.IsComputer) {
                Console.ReadKey(true);
            }

            int[] rolls = RollDice();
            int total = ProcessRolls(player, rolls);

            if (total == EndScore) {
                return true;
            }

            player.Score += total;

            Console.WriteLine($"{player.Name} score is {player.Score}");

            return false;
        }

        /// <summary>
        /// Method that rolls a specific number of dice.
        /// </summary>
        /// <param name="count">The number of dice to roll. Currently is 5.</param>
        /// <returns>The array of the dice rolls.</returns>
        private int[] RollDice(int count = DieCount) {
            return dice.Take(count).Select(d => d.Roll()).ToArray();
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

    }
}
