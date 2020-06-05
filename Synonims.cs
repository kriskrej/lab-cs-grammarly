using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Lab_CS_Grammarly {
    internal class Synonims {
        private string originalWord;

        public List<string> synonims = new List<string>();

        public Synonims(string originalWord) {
            this.originalWord = originalWord;
        }

        internal void Add(List<string> newSynonims) {
            synonims.AddRange(newSynonims);
        }

        public List<SynonimButtonData> GenerateButtonsData(Match selectedWord) {
            var buttonsData = new List<SynonimButtonData>();

            foreach (var synonim in synonims) {
                var btn = new SynonimButtonData();
                btn.label = synonim;
                btn.word = RemoveBraces(synonim);
                btn.color = GetColor(synonim);
                buttonsData.Add(btn);
            }

            return buttonsData;
        }

        private Color GetColor(string synonim) {

            if (CheckPoints(synonim) > 0)
                return Color.Green;
            if (CheckPoints(synonim) < 0)
                return Color.HotPink;

            return Color.Blue;
        }

        private int CheckPoints(string word) {
            foreach (var adj in adjectives) {
                if (word.Contains($"({adj.Key})"))
                    return adj.Value;
            }
            return 0;
        }

        Dictionary<string, int> adjectives = new Dictionary<string, int> {
            {"specjalistycznie", 2},
            {"książkowo", 1},
            {"rzadziej", 0},
            {"nieco potocznie", -1},
            {"żartobliwie", -1},
            {"ekspresywnie", -1},
            {"potocznie", -2},
            {"bardzo potocznie", -3},
        };


        private string RemoveBraces(string synonim) {
            foreach (var adj in adjectives)
                synonim = synonim.Replace($"({adj.Key}) ", "");
            return synonim;
        }
    }
}