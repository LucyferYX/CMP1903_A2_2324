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

        public override void Play() {
            Reset();

            while (true) {
                int roll1, roll2, total;

                // Player 1
                Console.WriteLine("\nPlayer 1 turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                roll1 = dice[0].Roll();
                roll2 = dice[1].Roll();
                total = roll1 + roll2;

                Console.WriteLine($"Player 1 rolled {total}");

                if (total == 7) {
                    break;
                }

                if (roll1 == roll2) {
                    total *= 2;
                }

                PlayerOne.Score += total;

                // Player 2
                Console.WriteLine(PlayerTwo.IsComputer ? "Computer turn." : "Player 2 turn. Press any key to roll the dice...");
                if (!PlayerTwo.IsComputer) {
                    Console.ReadKey(true);
                }
                roll1 = dice[0].Roll();
                roll2 = dice[1].Roll();
                total = roll1 + roll2;

                Console.WriteLine(PlayerTwo.IsComputer ? $"Computer rolled {total}" : $"Player 2 rolled {total}");

                if (total == 7) {
                    break;
                }

                if (roll1 == roll2) {
                    total *= 2;
                }

                PlayerTwo.Score += total;
            }
        }
    }
}
