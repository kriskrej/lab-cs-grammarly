using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_CS_Grammarly {
    internal class SynonimsDb {
        Dictionary<string, List<string>> synonims = new Dictionary<string, List<string>>();

        public SynonimsDb() {
            var lines = File.ReadAllLines("synonimy.txt");
            foreach(var line in lines) {
                var words = line.Split(';');
                var originalWord = words[0];
                var wordSynonims = words.Skip(1).ToList();
                synonims[originalWord] = wordSynonims;
            }
        }

        public List<string> Find(string word) {
            if (synonims.ContainsKey(word.ToLower()))
                return synonims[word.ToLower()];

            return new List<string>();
        }

        internal bool HasSynonimTo(string word) {
            return synonims.ContainsKey(word.ToLower());
        }
    }
}





















