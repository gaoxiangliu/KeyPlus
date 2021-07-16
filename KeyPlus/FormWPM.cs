using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormWPM : Form
    {
        private Graphics graph;
        private List<string> wordList = new List<string>();
        Random random = new Random();
        private List<List<int>> linesOfWords = new List<List<int>>();

        // number of characters in a line
        private int lowerBound = 70;
        private int upperBound = 75;

        private int currentWordInt;
        private int currentWordIndex;
        private string currentWordStr;

        // for calculating accuracy, total key down
        private int totalInputCount;
        private int totalBadInput;
        private int totalBackspace;

        // for display correct and wrong input character, words only
        private int wordCharTotal;
        private int wordCharBad;
        private int wordTotal;
        private int wordBad;

        private bool isCurentWordWrong;
        private int previousTextInputLength;

        private int countDown;

        public FormWPM()
        {
            InitializeComponent();
            graph = lblWords.CreateGraphics();
        }

        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            var textbox = (sender as TextBox);
            if (textbox == null)
            {
                return;
            }

            // Add support for CTRL+A  
            if (e.Control && e.KeyCode == Keys.A)
            {
                textbox.SelectAll();
            }

            // Add support for CTRL+Backspace  
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                if (textbox.SelectionStart > 0)
                {
                    /*  
                     * Piggyback off of the supported "CTRL + Left Cursor" feature.  
                     * Does not need to send {CTRL}, because the user is currently holding {CTRL}.  
                     * Uses {DEL} rather than {BKSP} in order to avoid creating an infinite loop.  
                     * NOTE: {DEL} has the side effect of deleting text to the right if the cursor is  
                     *       already as far left as it can go, since no text will be selected by {LEFT}.  
                     *       The .SelectionStart > 0 condition prevents this side effect.  
                     */
                    SendKeys.Send("+{LEFT}{DEL}");
                }
            }
            
            // for shortcut of reset
            if (e.KeyCode == Keys.F5)
            {
                Reset();
            }
        }

        private void FormWPM_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            LoadLanguage();
            LoadTestingWordsCombo();
            LoadWords();
            textInput.Enabled = false;
            Reset();
        }

        private void LoadLanguage()
        {
            this.Text = Language.GetText("skill_wpm");
            btnReset.Text = Language.GetText("reset") + "(F5)";
            lblInstruction.Text = Language.GetText("wpm_instruction");
            lblAccuracy.Text = Language.GetText("wpm_accruacy");
            lblBackspace.Text = Language.GetText("wpm_backspace");
            lblCorrectKeystrokes.Text = Language.GetText("wpm_correct_keystrokes");
            lblCorrectWords.Text = Language.GetText("wpm_correct_words");
            lblTotalKeystrokes.Text = Language.GetText("wpm_total_keystrokes");
            lblWrongKeystrokes.Text = Language.GetText("wpm_wrong_keystrokes");
            lblWrongWords.Text = Language.GetText("wpm_wrong_words");
            groupTestWords.Text = Language.GetText("testing_words");
            btnBrowse.Text = Language.GetText("browse");
        }

        private void LoadTestingWordsCombo()
        {
            // the last item will always be "Cutomize"
            comboBoxTestWords.Items.Clear();
            comboBoxTestWords.Items.Add(Language.GetText("lower_case"));
            comboBoxTestWords.Items.Add(Language.GetText("top_200"));
            comboBoxTestWords.Items.Add(Language.GetText("top_1000"));
            comboBoxTestWords.Items.Add(Language.GetText("toefl"));
            comboBoxTestWords.Items.Add(Language.GetText("gre"));
            comboBoxTestWords.Items.Add(Language.GetText("gmat"));
            comboBoxTestWords.Items.Add(Language.GetText("customize"));
            comboBoxTestWords.SelectedIndex = 0;
        }

        private void LoadWords()
        {
            string words;
            // the last item will always be "Cutomize"
            switch (comboBoxTestWords.SelectedIndex)
            {
                case 0:
                    words = Properties.Resources.words;
                    break;
                case 1:
                    words = Properties.Resources.words_top_200;
                    break;
                case 2:
                    words = Properties.Resources.words_top_1000;
                    break;
                case 3:
                    words = Properties.Resources.words_toefl;
                    break;
                case 4:
                    words = Properties.Resources.words_gre;
                    break;
                case 5:
                    words = Properties.Resources.words_gmat;
                    break;
                case 6:
                    if (lblPath.Text.Equals("path"))
                        words = Properties.Resources.words;
                    else
                    {
                        try
                        {
                            string[] lines = System.IO.File.ReadAllLines(lblPath.Text);
                            words = lines[0];
                        }
                        catch
                        {
                            MessageBox.Show(Language.GetText("bad_words_list"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            words = Properties.Resources.words;
                        }
                    }
                    break;
                default:
                    words = Properties.Resources.words;
                    break;
            }
            wordList.Clear();
            string[] wordArray = null;
            try
            {
                wordArray = words.Split('|');
            }
            catch
            {
                // Only customize mode can reach here
                // Something wrong with words list
                MessageBox.Show("");
                words = Properties.Resources.words;
                wordArray = words.Split('|');
            }
            Regex rx = new Regex(@"^([\x21-\x7E]){1,70}$");
            bool isWordsAccepted = true;
            foreach (var word in wordArray)
            {
                if (rx.IsMatch(word))
                {
                    var word1 = word.Trim();
                    if (!word1.Equals(""))
                        wordList.Add(word1);
                    else
                        isWordsAccepted = false;
                }
                else
                    isWordsAccepted = false;
            }
            if (!isWordsAccepted)
                MessageBox.Show(Language.GetText("words_not_accepted"), Language.GetText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (wordList.Count == 0)
            {
                comboBoxTestWords.SelectedIndex = 0;
                btnBrowse.Enabled = false;
                LoadWords();
            }
        }

        private void GenerateOneLineOfWords()
        {
            int characterCount = 0;
            List<int> line = new List<int>();
            int failureCount = 0;
            int timesOfRestart = 0;
            while (true)
            {
                int wordNum = random.Next(0, wordList.Count);
                string word = wordList[wordNum];
                characterCount += (word.Length + 1);
                if (characterCount <= lowerBound)
                {
                    line.Add(wordNum);
                }
                else if (characterCount > lowerBound && characterCount < upperBound)
                {
                    line.Add(wordNum);
                    break;
                }
                else if (characterCount >= upperBound)
                {
                    characterCount -= (word.Length + 1);
                    ++failureCount;
                }
                if (failureCount >= 100)
                {
                    if (timesOfRestart < 1)
                    {
                        characterCount = 0;
                        line.Clear();
                        failureCount = 0;
                        ++timesOfRestart;
                    }
                    else
                        break;
                }
            }
            linesOfWords.Add(line);
        }

        /// <summary>
        /// only for the first line
        /// </summary>
        /// <param name="wordPosition">starts from 0, index of the word</param>
        /// <param name="status">0: white, 1: grey, 2: red</param>
        private void PrintShadow(int wordPosition, int status)
        {
            string word = wordList[linesOfWords[0][wordPosition]];
            int charCount = 0;
            for (int i = 0; i < wordPosition; i++)
            {
                charCount += (wordList[linesOfWords[0][i]].Length + 1);
            }
            SolidBrush shadowBrush = new SolidBrush(Color.White);
            if (status == 1)
                shadowBrush = new SolidBrush(Color.LightGray);
            else if (status == 2)
                shadowBrush = new SolidBrush(Color.Red);
            graph.FillRectangle(shadowBrush, new Rectangle((int)(5 + charCount * (lblWords.Font.Size - 4)), 5,
                        (int)(5 + word.Length * (lblWords.Font.Size - 4)), (int)(lblWords.Font.Size * 2)));
        }

        /// <summary>
        /// only for the first line
        /// </summary>
        /// <param name="wordPosition">starts from 0, index of the word</param>
        /// <param name="status">0: black, 1: green, 2: red</param>
        private void PrintOneWord(int wordPosition, int status)
        {
            string word = wordList[linesOfWords[0][wordPosition]];
            int charCount = 0;
            for (int i = 0; i < wordPosition; i++)
            {
                charCount += (wordList[linesOfWords[0][i]].Length + 1);
            }
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            if (status == 1)
                drawBrush = new SolidBrush(Color.ForestGreen);
            else if (status == 2)
                drawBrush = new SolidBrush(Color.Red);
            graph.DrawString(word, lblWords.Font, drawBrush, 5 + charCount * (lblWords.Font.Size - 4), 10);

        }

        private void PrintTwoLines()
        {
            graph.Clear(Color.White);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int charCount = 0;
            int index = 0;
            foreach (int wordNum in linesOfWords[0])
            {
                graph.DrawString(wordList[wordNum], lblWords.Font, drawBrush, 5 + charCount * (lblWords.Font.Size - 4), 10);
                charCount += (wordList[wordNum].Length + 1);
                ++index;
            }
            charCount = 0;
            foreach (int wordNum in linesOfWords[1])
            {
                graph.DrawString(wordList[wordNum], lblWords.Font, drawBrush, 5 + charCount * (lblWords.Font.Size - 4), 50);
                charCount += (wordList[wordNum].Length + 1);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            linesOfWords.Clear();
            GenerateOneLineOfWords();
            GenerateOneLineOfWords();
            currentWordInt = linesOfWords[0][0];
            currentWordStr = wordList[currentWordInt];
            currentWordIndex = 0;
            totalBackspace = 0;
            totalBadInput = 0;
            totalInputCount = 0;
            isCurentWordWrong = false;
            wordCharTotal = 0;
            wordCharBad = 0;
            wordTotal = 0;
            wordBad = 0;
            countDown = 60;
            PrintTwoLines();
            PrintShadow(0, 1);
            PrintOneWord(0, 0);
            textInput.Text = "";
            textInput.Enabled = true;
            textInput.Focus();
            lblTime.Text = "1:00";
            timer1.Enabled = false;
            groupTestWords.Enabled = true;
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (textInput.Text.Length > previousTextInputLength)
                totalInputCount += (textInput.Text.Length - previousTextInputLength);
            if (!textInput.Text.Equals(""))
            {
                if (textInput.Text.Equals(" "))
                {
                    // remove leading useless space
                    textInput.Text = "";
                    --totalInputCount;
                }
                else if (textInput.Text.Substring(textInput.Text.Length - 1).Equals(" "))
                {
                    // finish typing a word, press space, move to the next one
                    ++wordTotal;
                    wordCharTotal += (currentWordStr.Length + 1);
                    if (textInput.Text.Length - 1 != currentWordStr.Length)
                        ++totalBadInput;
                    if (!textInput.Text.Substring(0, textInput.Text.Length - 1).Equals(currentWordStr))
                    {
                        // this word is wrong
                        ++wordBad;
                        wordCharBad += (currentWordStr.Length + 1);
                        PrintShadow(currentWordIndex, 0);
                        PrintOneWord(currentWordIndex, 2);
                    }
                    else
                    {
                        // this word is correct
                        PrintShadow(currentWordIndex, 0);
                        PrintOneWord(currentWordIndex, 1);
                    }

                    // move to the next word
                    if (currentWordIndex < linesOfWords[0].Count - 1) {
                        // in the same line
                        ++currentWordIndex;
                    }
                    else
                    {
                        // new line
                        GenerateOneLineOfWords();
                        linesOfWords.RemoveAt(0);
                        currentWordIndex = 0;
                        PrintTwoLines();
                    }
                    currentWordInt = linesOfWords[0][currentWordIndex];
                    currentWordStr = wordList[currentWordInt];
                    PrintShadow(currentWordIndex, 1);
                    PrintOneWord(currentWordIndex, 0);
                    textInput.Text = "";
                }
                else
                {
                    // input mornal characters
                    if (textInput.Text.Length < currentWordStr.Length)
                    {
                        if (!textInput.Text.Equals(currentWordStr.Substring(0, textInput.Text.Length)))
                            isCurentWordWrong = true;
                        else
                            isCurentWordWrong = false;
                    }
                    else if (textInput.Text.Length == currentWordStr.Length)
                    {
                        if (!textInput.Text.Equals(currentWordStr))
                            isCurentWordWrong = true;
                        else
                            isCurentWordWrong = false;
                    }
                    else if (textInput.Text.Length > currentWordStr.Length)
                        isCurentWordWrong = true;

                    // print red shadow if user inputs bad characters
                    if (isCurentWordWrong)
                    {
                        PrintShadow(currentWordIndex, 2);
                        PrintOneWord(currentWordIndex, 0);
                    }
                    else
                    {
                        PrintShadow(currentWordIndex, 1);
                        PrintOneWord(currentWordIndex, 0);
                    }
                    // count wrong input character
                    int tIndex = textInput.Text.Length - 1;
                    int tCount = textInput.Text.Length - previousTextInputLength;
                    while (tCount > 0)
                    {
                        if (tIndex > currentWordStr.Length - 1)
                            ++totalBadInput;
                        else if (textInput.Text[tIndex] != currentWordStr[tIndex])
                            ++totalBadInput;
                        --tIndex;
                        --tCount;
                    }
                }
            }
            else
            {
                isCurentWordWrong = false;
                PrintShadow(currentWordIndex, 1);
                PrintOneWord(currentWordIndex, 0);
            }
            //PrintTwoLines();
            previousTextInputLength = textInput.Text.Length;
        }

        private void textInput_KeyUp(object sender, KeyEventArgs e)
        {
            //debug();
            lblInstruction.Text = "";
            if (e.KeyCode != Keys.F5)
                groupTestWords.Enabled = false;
            if (e.KeyCode == Keys.Back)
                ++totalBackspace;
        }

        private void debug()
        {
            lblInstruction.Text = "";

            lblInstruction.Text += "currentWordInt " + currentWordInt.ToString() + "\n";
            lblInstruction.Text += "currentWordIndex " + currentWordIndex.ToString() + "\n";
            lblInstruction.Text += "currentWordStr " + currentWordStr + "\n";

            // for calculating accuracy, total key down
            lblInstruction.Text += "totalInputCount " + totalInputCount.ToString() + "\n";
            lblInstruction.Text += "totalBadInput " + totalBadInput.ToString() + "\n";
            lblInstruction.Text += "totalBackspace " + totalBackspace.ToString() + "\n";

            // for display correct and wrong input character, words only
            lblInstruction.Text += "wordCharTotal " + wordCharTotal.ToString() + "\n";
            lblInstruction.Text += "wordCharBad " + wordCharBad.ToString() + "\n";
            lblInstruction.Text += "wordTotal " + wordTotal.ToString() + "\n";
            lblInstruction.Text += "wordBad " + wordBad.ToString() + "\n";

            lblInstruction.Text += "previousTextInputLength " + previousTextInputLength + "\n";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PrintTwoLines();
            PrintShadow(0, 1);
            PrintOneWord(0, 0);
            timer2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            --countDown;
            if (countDown < 0)
            {
                timer1.Enabled = false;
                textInput.Enabled = false;
                int wpm = (int)Math.Round(((double)wordCharTotal - wordCharBad) / 5);
                double accuracy1 = (double)(totalInputCount - totalBadInput) / totalInputCount;
                double accuracy2 = (double)(wordCharTotal - wordCharBad) / wordCharTotal;
                double accuracy = (accuracy1 < accuracy2) ? accuracy1 : accuracy2;
                lblWPM.Text = wpm + " WPM";
                lblTextTotalKeystrokes.Text = wordCharTotal.ToString();
                lblTextWrongKeystrokes.Text = wordCharBad.ToString();
                lblTextCorrectKeystrokes.Text = (wordCharTotal - wordCharBad).ToString();
                NumberFormatInfo setPrecision = new NumberFormatInfo();
                setPrecision.NumberDecimalDigits = 2;
                lblTextAccuracy.Text = (accuracy * 100).ToString("N", setPrecision) + "%";
                lblTextBackspace.Text = totalBackspace.ToString();
                lblTextWrongWords.Text = wordBad.ToString();
                lblTextCorrectWords.Text = (wordTotal - wordBad).ToString();
                groupBox1.Visible = true;
                groupTestWords.Enabled = true;
                this.Focus();
                return;
            }
            if (countDown > 9)
                lblTime.Text = "0:" + countDown;
            else
                lblTime.Text = "0:0" + countDown;

        }

        private void FormWPM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Reset();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                lblPath.Text = openFileDialog1.FileName;
                LoadWords();
                Reset();
            }
        }

        private void comboBoxTestWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTestWords.SelectedIndex == comboBoxTestWords.Items.Count - 1)
            {
                // the last item will always be "Cutomize"
                lblInstruction.Text = Language.GetText("words_list_intro");
                btnBrowse.Enabled = true;
            }
            else
            {
                btnBrowse.Enabled = false;
                LoadWords();
                Reset();
            }
            if (comboBoxTestWords.SelectedIndex == 3 || comboBoxTestWords.SelectedIndex == 4 || comboBoxTestWords.SelectedIndex == 5)
            {
                lblInstruction.Text = Language.GetText("test_notice");
            }
            else if (comboBoxTestWords.SelectedIndex == 0 || comboBoxTestWords.SelectedIndex == 1 || comboBoxTestWords.SelectedIndex == 2)
            {
                lblInstruction.Text = Language.GetText("wpm_instruction");
            }
        }
    }
}
