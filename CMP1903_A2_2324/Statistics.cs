using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public class Statistics {
        public Dictionary<string, int> NumberOfPlays { get; } = [];

        public Dictionary<string, Tuple<int, int>> HighScores { get; } = [];

        public void UpdateStats(Game game) {
            string gameType = game.GetType().Name;

            if (!NumberOfPlays.TryGetValue(gameType, out int playValue)) {
                playValue = 0;
                NumberOfPlays[gameType] = playValue;
            }
            NumberOfPlays[gameType] = ++playValue;

            if (!HighScores.TryGetValue(gameType, out Tuple<int, int>? highScoreValue)) {
                highScoreValue = new Tuple<int, int>(0, 0);
                HighScores[gameType] = highScoreValue;
            }

            var currentHighScores = highScoreValue;
            int newPlayerOneHighScore = Math.Max(currentHighScores.Item1, game.PlayerOne.Score);
            int newPlayerTwoHighScore = Math.Max(currentHighScores.Item2, game.PlayerTwo.Score);

            HighScores[gameType] = new Tuple<int, int>(newPlayerOneHighScore, newPlayerTwoHighScore);
        }

        public int GetNumberOfPlays(string gameType) {
            if (NumberOfPlays.TryGetValue(gameType, out int numberOfPlays)) {
                return numberOfPlays;
            }
            return 0;
        }

        public int GetHighScore(string gameType, int playerNumber) {
            if (HighScores.TryGetValue(gameType, out Tuple<int, int>? value)) {
                return playerNumber == 1 ? value.Item1 : value.Item2;
            }
            return 0;
        }
    }
}
