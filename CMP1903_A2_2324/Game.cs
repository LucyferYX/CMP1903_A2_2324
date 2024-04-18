using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {

    public abstract class Game {
        protected readonly Die[] dice;

        public IPlayer PlayerOne { get; }
        public IPlayer PlayerTwo { get; }

        public Game(int numberOfDice, IPlayer playerOne, IPlayer playerTwo) {
            dice = new Die[numberOfDice];
            for (int i = 0; i < numberOfDice; i++) {
                dice[i] = new Die();
            }

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public abstract void Play();

        protected void Reset() {
            PlayerOne.Score = 0;
            PlayerTwo.Score = 0;
        }
    }
}
