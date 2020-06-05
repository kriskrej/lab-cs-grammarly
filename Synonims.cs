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
                btn.word = synonim;
                btn.color = Color.Black;

                buttonsData.Add(btn);
            }

            return buttonsData;
        }
    }
}