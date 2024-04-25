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
        /// Tests results of a game ending correctly.
        /// </summary>
        /// <param name="game">The game being tested.</param>
        public static void TestingThreeOrMoreEndScore(ThreeOrMore game) {
            Debug.Assert(game.PlayerOne.Score >= ThreeOrMoreEndScore || game.PlayerTwo.Score >= ThreeOrMoreEndScore, $"ThreeOrMore game should end when one of the players have scored {ThreeOrMoreEndScore} or more. {game.PlayerOne.Name} score: {game.PlayerOne.Score}, {game.PlayerTwo.Name} score: {game.PlayerTwo.Score}.");
        }

        public static void TestingSevensOutEndScore(bool isGameOver, int total) {
            Debug.Assert(!(total == SevensOutEndScore && !isGameOver), $"SevensOut game should end when player rolls {SevensOutEndScore}. Score rolled was {total} and the game did not end.");
            Debug.Assert(!(total != SevensOutEndScore && isGameOver), $"SevensOut game should end when player rolls {SevensOutEndScore}. Score rolled was {total} and the game ended.");
        }

        public static void VerifyTotalSum(int total, int expectedTotal) {
            Debug.Assert(total == expectedTotal, $"Test Failed: The total sum of the dice rolls should be {expectedTotal}, but it was {total}.");
        }
    }

}
