using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public class Statistics {
        /// <summary>
        /// Dictionary to hold number of plays for each game.
        /// Key = game type. Value = number of plays.
        /// </summary>
        public Dictionary<string, int> NumberOfPlays { get; } = [];

        /// <summary>
        /// Dictionary to hold high scores for each game.
        /// Key = game type. Value = tuple holding high scores of player 1 and player 2.
        /// </summary>
        public Dictionary<string, Tuple<int, int>> HighScores { get; } = [];

        /// <summary>
        /// Method that updates the statistics of games and players
        /// </summary>
        /// <param name="game">Game for which to update statistics for.</param>
        public void UpdateStats(Game game) {
            string gameType = game.GetType().Name;

            UpdateNumberOfPlays(gameType);
            UpdateHighScores(gameType, game.PlayerOne.Score, game.PlayerTwo.Score);
        }

        /// <summary>
        /// Method that updates the number of plays for a game.
        /// </summary>
        /// <param name="gameType">The type of the game.</param>
        private void UpdateNumberOfPlays(string gameType) {
            if (!NumberOfPlays.TryGetValue(gameType, out int playValue)) {
                playValue = 0;
            }
            NumberOfPlays[gameType] = ++playValue;
        }

        /// <summary>
        /// Method that updates the high scores for a game.
        /// </summary>
        /// <param name="gameType">The type of the game.</param>
        /// <param name="playerOneScore">The score of player one.</param>
        /// <param name="playerTwoScore">The score of player two.</param>
        private void UpdateHighScores(string gameType, int playerOneScore, int playerTwoScore) {
            if (!HighScores.TryGetValue(gameType, out Tuple<int, int>? highScoreValue)) {
                highScoreValue = new Tuple<int, int>(0, 0);
            }

            int newPlayerOneHighScore = Math.Max(highScoreValue.Item1, playerOneScore);
            int newPlayerTwoHighScore = Math.Max(highScoreValue.Item2, playerTwoScore);

            HighScores[gameType] = new Tuple<int, int>(newPlayerOneHighScore, newPlayerTwoHighScore);
        }

        /// <summary>
        /// Method that gets number of plays for a game.
        /// </summary>
        /// <param name="gameType">The type of the game.</param>
        /// <returns>Returns number of plays for the game, returns 0 if no games were played.</returns>
        public int GetNumberOfPlays(string gameType) {
            if (NumberOfPlays.TryGetValue(gameType, out int numberOfPlays)) {
                return numberOfPlays;
            }
            return 0;
        }

        /// <summary>
        /// Method that gets the player high score for a game.
        /// </summary>
        /// <param name="gameType">The type of the game.</param>
        /// <param name="playerNumber">The number of the player.</param>
        /// <returns></returns>
        public int GetHighScore(string gameType, int playerNumber) {
            if (HighScores.TryGetValue(gameType, out Tuple<int, int>? value)) {
                return playerNumber == 1 ? value.Item1 : value.Item2;
            }
            return 0;
        }
    }
}
