using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public class SevensOut {
        private readonly Die _die1 = new();
        private readonly Die _die2 = new();

        public int PlayerOneScore {
            get;
            private set;
        }

        public int PlayerTwoScore {
            get;
            private set;
        }

        public void Reset() {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }

        public void Play(bool isComputer) {
            Reset();

            while (true) {
                int roll1, roll2, total;

                // Player 1
                Console.WriteLine("\nPlayer 1 turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                roll1 = _die1.Roll();
                roll2 = _die2.Roll();
                total = roll1 + roll2;

                Console.WriteLine($"Player 1 rolled {total}");

                if (total == 7) {
                    break;
                }

                if (roll1 == roll2) {
                    total *= 2;
                }

                PlayerOneScore += total;

                // Player 2
                Console.WriteLine(isComputer ? "Computer turn." : "Player 2 turn. Press any key to roll the dice...");
                if (!isComputer) {
                    Console.ReadKey(true);
                }
                roll1 = _die1.Roll();
                roll2 = _die2.Roll();
                total = roll1 + roll2;

                Console.WriteLine(isComputer ? $"Computer rolled {total}" : $"Player 2 rolled {total}");

                if (total == 7) {
                    break;
                }

                if (roll1 == roll2) {
                    total *= 2;
                }

                PlayerTwoScore += total;
            }
        }
    }
}
