using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_CS_Grammarly {
    internal class SynonimsDb {
        Dictionary<string, Synonims> synonims = new Dictionary<string, Synonims>();

        public SynonimsDb() {
            var lines = File.ReadAllLines("synonimy.txt");
            foreach(var line in lines) {
                var words = line.Split(';');
                var originalWord = words[0];
                var wordSynonims = words.Skip(1).ToList();

                if (!synonims.ContainsKey(originalWord))
                    synonims[originalWord] = new Synonims(originalWord);
                synonims[originalWord].Add(wordSynonims);
            }
        }

        public Synonims Find(string word) {
            var found = synonims[word.ToLower()];
            if (found != null) 
                Console.WriteLine($"{found.synonims.Count} synonims for word /{word}/ found.");
                
            return found;
        }

        internal bool HasSynonimTo(string word) {
            return synonims.ContainsKey(word.ToLower());
        }
    }
}





















