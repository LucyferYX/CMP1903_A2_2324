using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// For Debug.Assert()
using System.Diagnostics;
using CMP1903_A2_2324;

namespace CMP1903_A1_2324 {
    internal class Testing {
        /// <summary>
        /// The score at which the SevensOut game ends.
        /// </summary>
        private const int SevensOutEndScore = 7;

        /// <summary>
        /// The score at which the ThreeOrMore game ends.
        /// </summary>
        private const int ThreeOrMoreEndScore = 20;


        /// <summary>
        /// Method that verifies that the ThreeOrMore game ends when one of the players has scored equal to or more than the specified score.
        /// </summary>
        /// <param name="game">The ThreeOrMore game instance.</param>
        public static void TestingThreeOrMoreEndScore(ThreeOrMore game) {
            Debug.Assert(
                game.PlayerOne.Score >= ThreeOrMoreEndScore || game.PlayerTwo.Score >= ThreeOrMoreEndScore,
                $"ThreeOrMore game should end when one of the players has scored {ThreeOrMoreEndScore} or more. " +
                $"{game.PlayerOne.Name} score: {game.PlayerOne.Score}, {game.PlayerTwo.Name} score: {game.PlayerTwo.Score}.");
        }

        /// <summary>
        /// Method that verifies that the SevensOut game ends correctly based on the total rolled score.
        /// </summary>
        /// <param name="isGameOver">Indicates whether the game is over.</param>
        /// <param name="total">The total score rolled by the player.</param>
        public static void TestingSevensOutEndScore(bool isGameOver, int total) {
            Debug.Assert(
                !(total == SevensOutEndScore && !isGameOver),
                $"SevensOut game should end when player rolls {SevensOutEndScore}. Score rolled was {total} and the game did not end.");
            Debug.Assert(
                !(total != SevensOutEndScore && isGameOver),
                $"SevensOut game should end when player rolls {SevensOutEndScore}. Score rolled was {total} and the game ended.");
        }

        /// <summary>
        /// Method that verifies that the total sum of dice rolls in the SevensOut game matches the expected total.
        /// </summary>
        /// <param name="total">The actual total sum of dice rolls.</param>
        /// <param name="expectedTotal">The expected total sum.</param>
        public static void TestingSevensOutTotalSum(int total, int expectedTotal) {
            Debug.Assert(
                total == expectedTotal,
                $"Test Failed: The total sum of the dice rolls should be {expectedTotal}, but it was {total}.");
        }

        /// <summary>
        /// Method that verifies that the player's score in the ThreeOrMore game matches the expected score.
        /// </summary>
        /// <param name="game">The ThreeOrMore game instance.</param>
        /// <param name="player">The player whose score is being tested.</param>
        /// <param name="expectedScore">The expected score.</param>
        public static void TestingThreeOrMoreTotalSum(IPlayer player, int expectedScore) {
            Debug.Assert(
                player.Score == expectedScore,
                $"Test Failed: The player's score should be {expectedScore}, but it was {player.Score}.");
        }

    }

}
