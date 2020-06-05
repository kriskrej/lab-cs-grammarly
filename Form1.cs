using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab_CS_Grammarly {
    public partial class Form1 : Form {
        VulgarismsDb vulgarismsDb = new VulgarismsDb();
        SynonimsDb synonimsDb = new SynonimsDb(); 

        public Form1() {
            InitializeComponent();
        }

        void OnTextChangedEventHandler(object sender, EventArgs e) {
            RemoveHighlights();
            HighlightInterestingWords();
        }

        void ShowSynonimsForSelectedWord() {
            synonimButtons.Controls.Clear();
            var selectedWord = FindSelectedWord();
            if (selectedWord == null)
                return;
            AddSynonimButtons(selectedWord);
        }

        private void AddSynonimButtons(Match selectedWord) {
            var synonims = synonimsDb.Find(selectedWord.Value);
            foreach (var synonim in synonims) {
                var btn = new Button();
                btn.Text = synonim;
                btn.Click += (o, i) => { ReplaceWord(selectedWord, synonim); };
                synonimButtons.Controls.Add(btn);
            }
        }

        private void ReplaceWord(Match selectedWord, string synonim) {
            input.Select(selectedWord.Index, selectedWord.Length);
            input.SelectedText = synonim;
        }

        Match FindSelectedWord() {
            var wordsRegex = new Regex(@"(\b[^\s]+\b)");
            var allWords = wordsRegex.Matches(input.Text);
            foreach (Match word in allWords) {
                var cursorPosition = input.SelectionStart;
                var wordBegin = word.Index;
                var wordEnd = wordBegin + word.Length;
                if (cursorPosition < wordEnd)
                    return word;
            }
            return null;
        }

        void RemoveHighlights() {
            MarkUsingColor(0, 900000, Color.Black);
        }

        void HighlightInterestingWords() {
            var wordsRegex = new Regex(@"(\b[^\s]+\b)");
            var allWords = wordsRegex.Matches(input.Text);
            foreach (Match word in allWords) {
                if (synonimsDb.HasSynonimTo(word.Value))
                    MarkUsingColor(word.Index, word.Length, Color.Blue);
                if (vulgarismsDb.IsBadWord(word))
                    MarkUsingColor(word.Index, word.Length, Color.Red);
            }
        }

        void MarkUsingColor(int startPosition, int length, Color color) {
            var selectionStart = input.SelectionStart;
            input.Select(startPosition, length);
            input.SelectionColor = color;
            input.SelectionStart = selectionStart;
            input.SelectionLength = 0;
        }

        private void ShowSynonimsForSelectedWord(object sender, EventArgs e) {
            ShowSynonimsForSelectedWord();
        }
    }
}
