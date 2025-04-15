using System;
using System.Windows.Forms;

namespace Tic_Tac_toe
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private char currentPlayer = 'X';
        private int movesCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            buttons = new Button[9];
            this.Text = "Tic-Tac-Toe";
            this.Size = new System.Drawing.Size(350, 400);

            Label turnLabel = new Label
            {
                Text = "Player X's Turn",
                Location = new System.Drawing.Point(100, 20),
                Font = new System.Drawing.Font("Arial", 12),
                AutoSize = true
            };
            this.Controls.Add(turnLabel);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button
                {
                    Size = new System.Drawing.Size(80, 80),
                    Location = new System.Drawing.Point(50 + (i % 3) * 85, 70 + (i / 3) * 85),
                    Font = new System.Drawing.Font("Arial", 24),
                    Tag = i
                };
                buttons[i].Click += Button_Click;
                this.Controls.Add(buttons[i]);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Text != "")
                return;

            clickedButton.Text = currentPlayer.ToString();
            movesCount++;

            if (CheckWin())
            {
                MessageBox.Show($"Player {currentPlayer} Wins!", "Game Over", MessageBoxButtons.OK);
                ResetGame();
            }
            else if (movesCount == 9)
            {
                MessageBox.Show("It's a Draw!", "Game Over", MessageBoxButtons.OK);
                ResetGame();
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                foreach (Control control in this.Controls)
                {
                    if (control is Label)
                        control.Text = $"Player {currentPlayer}'s Turn";
                }
            }
        }

        private bool CheckWin()
        {
            int[,] winConditions = new int[,]
            {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                int a = winConditions[i, 0];
                int b = winConditions[i, 1];
                int c = winConditions[i, 2];

                if (buttons[a].Text == buttons[b].Text &&
                    buttons[b].Text == buttons[c].Text &&
                    buttons[a].Text != "")
                {
                    return true;
                }
            }

            return false;
        }

        private void ResetGame()
        {
            foreach (Button button in buttons)
                button.Text = "";

            currentPlayer = 'X';
            movesCount = 0;

            foreach (Control control in this.Controls)
            {
                if (control is Label)
                    control.Text = "Player X's Turn";
            }
        }
    }
}   