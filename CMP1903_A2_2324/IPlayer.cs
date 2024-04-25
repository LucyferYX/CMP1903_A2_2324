using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    /// <summary>
    /// Interface for player that will play games.
    /// </summary>
    public interface IPlayer {
        string Name { 
            get;
        }
        int Score { 
            get;
            set; 
        }
        bool IsComputer { 
            get; 
        }
    }

    /// <summary>
    /// Struct of player that will play games.
    /// </summary>
    public struct Player : IPlayer {
        public string Name { 
            get; 
            set; 
        }
        public int Score { 
            get; 
            set; 
        }
        public bool IsComputer { 
            get; 
            set; 
        }
    }
}
