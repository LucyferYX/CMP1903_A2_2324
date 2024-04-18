using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324 {
    public interface IPlayer {
        string Name { get; }
        int Score { get; set; }
        bool IsComputer { get; }
    }

    public struct Player : IPlayer {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsComputer { get; set; }
    }
}
