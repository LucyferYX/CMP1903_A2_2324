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
        public int PlayerOneHighScore {
            get;
            private set;
        }
        public int PlayerTwoHighScore { 
            get; 
            private set;
        }

        public void UpdateStats(SevensOut game) {
            NumberOfPlays++;
            PlayerOneHighScore = Math.Max(PlayerOneHighScore, game.PlayerOneScore);
            PlayerTwoHighScore = Math.Max(PlayerTwoHighScore, game.PlayerTwoScore);
        }
    }
}
