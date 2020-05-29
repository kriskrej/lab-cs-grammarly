using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_CS_Grammarly {
    internal class VulgarismsDb {
        List<string> vulgarisms;
        public VulgarismsDb() {
            vulgarisms = File.ReadAllLines("wulgaryzmy.txt").ToList();
        }

        internal bool IsBadWord(Match word) {
            return vulgarisms.Contains(word.Value.ToLower());
        }
    }
}