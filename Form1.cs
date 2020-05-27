using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_CS_Grammarly {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        void OnTextChangedEventHandler(object sender, EventArgs e) {
            RemoveHighlights();
            HighlightAllForbiddenWords();
        }

        void RemoveHighlights() {
            MarkUsingColor(0, 900000, Color.Black);
        }

        void HighlightAllForbiddenWords() {
            var forbiddenWordsFinder = new Regex("(test1|test2)");
            var badWords = forbiddenWordsFinder.Matches(input.Text);
            foreach (Match badWord in badWords)
                MarkUsingColor(badWord.Index, badWord.Length, Color.Red);
        }

        void MarkUsingColor(int startPosition, int length, Color color) {
            var selectionStart = input.SelectionStart;
            input.Select(startPosition, length);
            input.SelectionColor = color;
            input.SelectionStart = selectionStart;
            input.SelectionLength = 0;
        }
    }
}
