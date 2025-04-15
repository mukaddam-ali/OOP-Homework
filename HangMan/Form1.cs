namespace HangMan
{
    public partial class Form1 : Form
    {
        private List<TextBox> textBoxes = [];
        private string[] words =
        [
            // 3-letter words
            "cat", "dog", "bat", "sun", "pen",

            // 4-letter words
            "tree", "moon", "star", "fish", "book",

            // 5-letter words
            "apple", "table", "chair", "light", "house",

            // 6-letter words
            "planet", "forest", "bottle", "camera", "rabbit",

            // 7-letter words
            "program", "diamond", "library", "monster", "guitar",

            // 8-letter words
            "elephant", "notebook", "football", "telescope", "umbrella",

            // 9-letter words
            "adventure", "chocolate", "pineapple", "fantastic", "telephone",

            // 10-letter words
            "watermelon", "basketball", "computer", "restaurant", "chocolate"
        ];
        private string word = "";
        private List<string> LettersChecked = [];
        private string chancesLeft = "\u2665 \u2665 \u2665 \u2665 \u2665 \u2665"; // ♥ 

        public Form1()
        {
            InitializeComponent();
            RandomWordSelector();
            textBox3.Text = chancesLeft;
            textBox4.Text = word.Length.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();

            chancesLeft = "\u2665 \u2665 \u2665 \u2665 \u2665 \u2665";
            textBox3.Text = chancesLeft;

            ClearTextBoxes();
            RandomWordSelector();

            textBox4.Text = word.Length.ToString();
        }

        private void CreateTextBox()
        {
            var textbox = new TextBox
            {
                Text = "_",
                Size = new Size(40, 20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Font = new Font("Arial", 12, FontStyle.Regular),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Center
            };
            textBoxes.Add(textbox);
            panel1.Controls.Add(textbox);
        }

        private void AdjustTextBoxPositions()
        {
            var textBoxCount = textBoxes.Count;
            if (textBoxCount == 0) return;

            var totalWidth = textBoxCount * 40;
            var startX = (panel1.Width - totalWidth) / 2;

            for (var i = 0; i < textBoxCount; i++)
            {
                textBoxes[i].Location = new Point(startX + (i * 40), 10);
            }
        }

        private void RandomWordSelector()
        {
            var random = new Random();
            word = words[random.Next(words.Length)];
            LettersChecked.Clear();

            for (var i = 0; i < word.Length; i++)
            {
                CreateTextBox();
            }

            AdjustTextBoxPositions();
        }

        private void ClearTextBoxes()
        {
            foreach (var textBox in textBoxes)
            {
                panel1.Controls.Remove(textBox);
            }
            textBoxes.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text.Length != 1)
            {
                textBox2.Text = "Please enter a single letter.";
                return;
            }

            var guessedLetter = textBox1.Text.ToLower();

            if (LettersChecked.Contains(guessedLetter))
            {
                textBox2.Text = "You have already checked this letter.";
                return;
            }

            var found = false;

            for (var i = 0; i < word.Length; i++)
            {
                if (word[i].ToString() != guessedLetter) continue;
                textBoxes[i].Text = guessedLetter;
                found = true;
            }

            if (found)
            {
                LettersChecked.Add(guessedLetter);
                textBox2.Text = "Correct!";
            }
            else
            {
                LettersChecked.Add(guessedLetter);
                textBox2.Text = "Incorrect letter!";

                if (chancesLeft.Length > 2)
                {
                    chancesLeft = chancesLeft[..^2];
                    textBox3.Text = chancesLeft;
                }

                else
                {
                    chancesLeft = "";
                    textBox3.Text = "";
                    textBox2.Text = "Game Over! The word is :";
                    for (var i = 0; i < word.Length; i++)
                    {
                        textBoxes[i].Text = word[i].ToString();
                    }

                    textBox1.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
