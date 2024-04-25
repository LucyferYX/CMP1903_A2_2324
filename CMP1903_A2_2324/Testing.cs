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
        public static void TestingResults(Game game) {
            if (game is SevensOut sevensOutGame) {
                Debug.Assert(sevensOutGame.PlayerOne.Score == SevensOutEndScore || sevensOutGame.PlayerTwo.Score != SevensOutEndScore, $"SevensOut game should end when player rolls {SevensOutEndScore}. Total score gotten: {SevensOutEndScore}.");
            }

            if (game is ThreeOrMore threeOrMoreGame) {
                Debug.Assert(threeOrMoreGame.PlayerOne.Score >= ThreeOrMoreEndScore || threeOrMoreGame.PlayerTwo.Score >= ThreeOrMoreEndScore, $"ThreeOrMore game should end when one of the players have scored {ThreeOrMoreEndScore} or more. {threeOrMoreGame.PlayerOne.Name} score: {threeOrMoreGame.PlayerOne.Score}, {threeOrMoreGame.PlayerTwo.Name} score: {threeOrMoreGame.PlayerTwo.Score}.");
            }
        }
    }

}
