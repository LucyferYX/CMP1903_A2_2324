using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*Three or More
5 x dice
Rules:
	Roll all 5 dice hoping for a 3-of-a-kind or better.
	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	3-of-a-kind: 3 points
	4-of-a-kind: 6 points
	5-of-a-kind: 12 points
    First to a total of 20.*/

namespace CMP1903_A2_2324 {
    public class ThreeOrMore(IPlayer playerOne, IPlayer playerTwo) : Game(5, playerOne, playerTwo) {
        public override void Play() {
            Reset();

            while (PlayerOne.Score < 20 && PlayerTwo.Score < 20) {
                // Player 1
                Console.WriteLine("\nPlayer 1 turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                int[] rolls = RollDice();
                Console.WriteLine($"Player 1 rolled {string.Join(", ", rolls)}");
                PlayerOne.Score += CalculateScore(rolls);

                // Player 2
                Console.WriteLine(PlayerTwo.IsComputer ? "Computer turn." : "Player 2 turn. Press any key to roll the dice...");
                if (!PlayerTwo.IsComputer) {
                    Console.ReadKey(true);
                }
                rolls = RollDice();
                Console.WriteLine(PlayerTwo.IsComputer ? $"Computer rolled {string.Join(", ", rolls)}" : $"Player 2 rolled {string.Join(", ", rolls)}");
                PlayerTwo.Score += CalculateScore(rolls);
            }
        }

        private int[] RollDice() {
            return dice.Select(d => d.Roll()).ToArray();
        }

        private static int CalculateScore(int[] rolls) {
            var counts = new int[6];
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
