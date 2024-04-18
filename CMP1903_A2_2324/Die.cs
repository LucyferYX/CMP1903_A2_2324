﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    public class Die {
        private const int MinDie = 1;
        private const int MaxDie = 6;
        /// <summary>
        /// 
        /// </summary>
        public int DieValue {
            get;
            private set;
        }

        private static readonly Random _random = new();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Roll() {
            DieValue = _random.Next(MinDie, MaxDie+1);
            return DieValue;
        }
    }
}
