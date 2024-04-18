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
                if (PlayTurn(PlayerOne, "\nPlayer 1 turn. Press any key to roll the dice...", "Player 1 rolled ")) {
                    break;
                }

                if (PlayTurn(PlayerTwo, PlayerTwo.IsComputer ? "Computer turn." : "Player 2 turn. Press any key to roll the dice...", PlayerTwo.IsComputer ? "Computer rolled " : "Player 2 rolled ")) {
                    break;
                }
            }
        }

        private bool PlayTurn(IPlayer player, string turnMessage, string rollMessage) {
            Console.WriteLine(turnMessage);
            if (!player.IsComputer) {
                Console.ReadKey(true);
            }
            int roll1 = dice[0].Roll();
            int roll2 = dice[1].Roll();
            int total = roll1 + roll2;

            if (roll1 == roll2) {
                Console.WriteLine($"{rollMessage}{total}! Double points {total*2}! ({roll1},{roll2})");
            } else {
                Console.WriteLine($"{rollMessage}{total}! ({roll1},{roll2})");
            }

            if (total == 7) {
                return true;
            }

            if (roll1 == roll2) {
                total *= 2;
            }

            player.Score += total;

            return false;
        }
    }
}
