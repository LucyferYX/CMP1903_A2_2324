using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public abstract class Game {
        /// <summary>
        /// Array of dice that will be rolled in the game.
        /// </summary>
        protected readonly Die[] dice;

        /// <summary>
        /// Gets the players that will play in the game.
        /// </summary>
        public IPlayer PlayerOne { get; }
        public IPlayer PlayerTwo { get; }

        /// <summary>
        /// Constructor method that initializes a new instance of the Game class.
        /// </summary>
        /// <param name="diceCount">The number of dice that will be rolled in the game.</param>
        /// <param name="playerOne">The first player that will play in the game.</param>
        /// <param name="playerTwo">The second player that will play in the game.</param>
        public Game(int diceCount, IPlayer playerOne, IPlayer playerTwo) {
            dice = new Die[diceCount];
            for (int i = 0; i < diceCount; i++) {
                dice[i] = new Die();
            }

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        /// <summary>
        /// Method that will start and continue the game.
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Method that resets player's scores.
        /// </summary>
        protected void Reset() {
            PlayerOne.Score = 0;
            PlayerTwo.Score = 0;
        }

        /// <summary>
        /// Method that rolls a specific number of dice.
        /// </summary>
        /// <param name="count">The number of dice to roll.</param>
        /// <returns>The array of the dice rolls.</returns>
        protected int[] RollDice(int count) {
            return dice.Take(count).Select(d => d.Roll()).ToArray();
        }
    }
}
