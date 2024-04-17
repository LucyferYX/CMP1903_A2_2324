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
        // Method
        public void TestingResults() {
            // Tests 
            // Debug.Assert();
        }
    }

    public class Statistics {
        public int NumberOfPlays {
            get;
            private set;
        }
        public Dictionary<string, Tuple<int, int>> HighScores { get; } = [];

        public void UpdateStats(Game game) {
            NumberOfPlays++;
            string gameType = game.GetType().Name;

            //if (!HighScores.ContainsKey(gameType)) {
                //HighScores[gameType] = new Tuple<int, int>(0, 0);
            //}

            var currentHighScores = HighScores[gameType];
            int newPlayerOneHighScore = Math.Max(currentHighScores.Item1, game.PlayerOne.Score);
            int newPlayerTwoHighScore = Math.Max(currentHighScores.Item2, game.PlayerTwo.Score);

            HighScores[gameType] = new Tuple<int, int>(newPlayerOneHighScore, newPlayerTwoHighScore);
        }
    }

}
