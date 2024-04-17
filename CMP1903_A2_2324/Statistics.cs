using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public class Statistics {
        public int NumberOfPlays {
            get;
            private set;
        }
        public Dictionary<string, Tuple<int, int>> HighScores { get; } = [];

        public void UpdateStats(Game game) {
            NumberOfPlays++;
            string gameType = game.GetType().Name;

            if (!HighScores.TryGetValue(gameType, out Tuple<int, int>? value)) {
                value = new Tuple<int, int>(0, 0);
                HighScores[gameType] = value;
            }

            var currentHighScores = value;
            int newPlayerOneHighScore = Math.Max(currentHighScores.Item1, game.PlayerOne.Score);
            int newPlayerTwoHighScore = Math.Max(currentHighScores.Item2, game.PlayerTwo.Score);

            HighScores[gameType] = new Tuple<int, int>(newPlayerOneHighScore, newPlayerTwoHighScore);
        }

        public int GetHighScore(string gameType, int playerNumber) {
            if (HighScores.TryGetValue(gameType, out Tuple<int, int>? value)) {
                return playerNumber == 1 ? value.Item1 : value.Item2;
            }
            return 0;
        }
    }
}
