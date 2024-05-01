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
        /// Gets the Player 1 that will play in the game.
        /// </summary>
        public IPlayer PlayerOne { get; }
        /// <summary>
        /// Gets the Player 2 that will play in the game.
        /// </summary>
        public IPlayer PlayerTwo { get; }

        /// <summary>
        /// Constructor method that initializes a new instance of the Game class.
        /// </summary>
        /// <param name="diceCount">The number of dice that will be rolled in the game.</param>
        /// <param name="playerOne">The first player that will play in the game.</param>
        /// <param name="playerTwo">The second player that will play in the game.</param>
        protected Game(int diceCount, IPlayer playerOne, IPlayer playerTwo) {
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
        // Example of LINQ and method overloading
        protected int[] RollDice(int count) {
            return dice.Take(count).Select(d => d.Roll()).ToArray();
        }

        /// <summary>
        /// Method that re-rolls the remaining dice after two of a kind dice are found.
        /// </summary>
        /// <param name="rolls">The array of dice rolls.</param>
        /// <param name="i">The index of the two of a kind in the counts array.</param>
        /// <returns>The new array of dice rolls after re-rolling the remaining dice.</returns>
        protected int[] RollDice(int dieCount, int[] rolls, int i) {
            try {
                int rollCount = 0;

                int[] newRolls = rolls.Select((roll, index) => {
                    if (roll == i + 1 && rollCount < 2) {
                        rollCount++;
                        return roll;
                    } else {
                        return RollDice(1)[0];
                    }
                }).ToArray();

                return newRolls;
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}. Rolls could not be re-rolled.");
                return new int[dieCount];
            }
        }

        /// <summary>
        /// Method that outputs line about player's turn.
        /// </summary>
        /// <param name="player">The current player.</param>
        protected static void WriteTurnMessage(IPlayer player) {
            Console.WriteLine(player.IsComputer ? $"\n{player.Name} turn." : $"\n{player.Name} turn. Press any key to roll the dice...");
        }

        /// <summary>
        /// Method that outputs line about player's score.
        /// </summary>
        /// <param name="player">The current player.</param>
        protected static void WriteScoreMessage(IPlayer player) {
            Console.WriteLine($"{player.Name} score is {player.Score}");
        }
    }
}
