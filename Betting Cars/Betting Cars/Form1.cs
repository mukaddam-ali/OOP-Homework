using System;
using System.Drawing;
using System.Windows.Forms;

namespace Betting_Cars
{
    public partial class Form1 : Form
    {
        private int car1Location = 15;
        private int car2Location = 15;
        private int car3Location = 15;
        private int finishLine;
        private Random random = new Random(); // Single Random object
        private string player;
        private string winner;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move the cars forward randomly
            car1Location += random.Next(1, 10);
            car2Location += random.Next(1, 10);
            car3Location += random.Next(1, 10);

            // Update the positions of the cars
            car1.Location = new Point(car1Location, car1.Location.Y);
            car2.Location = new Point(car2Location, car2.Location.Y);
            car3.Location = new Point(car3Location, car3.Location.Y);

            // Check if any car has crossed the finish line
            if (car1Location >= finishLine || car2Location >= finishLine || car3Location >= finishLine)
            {
                timer1.Stop();

                // Determine the winner
                if (car1Location >= finishLine)
                {
                    winner = "Orange Car";
                }
                else if (car2Location >= finishLine)
                {
                    winner = "Black Car";
                }
                else if (car3Location >= finishLine)
                {
                    winner = "Red Car";
                }

                // Show the result to the player
                if (player == winner)
                {
                    MessageBox.Show("You win!");
                }
                else
                {
                    MessageBox.Show($"You lose! {winner} wins!");
                }

                // Reset the game
                buttonReset();
                ResetCars();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            // Disable buttons during the race
            buttonDisable();

            // Reset car positions
            car1Location = 15;
            car2Location = 15;
            car3Location = 15;

            // Calculate the finish line based on the panel width
            finishLine = panel1.Width - car1.Width - 55; // Adjusted for panel

            // Reset car locations visually
            ResetCars();

            // Start the race
            timer1.Start();
        }

        private void redBtn_Click(object sender, EventArgs e)
        {
            player = "Red Car";
            SetButtonColors(redBtn);
        }

        private void blackBtn_Click(object sender, EventArgs e)
        {
            player = "Black Car";
            SetButtonColors(blackBtn);
        }

        private void orangeBtn_Click(object sender, EventArgs e)
        {
            player = "Orange Car";
            SetButtonColors(orangeBtn);
        }

        private void SetButtonColors(Button selectedButton)
        {
            // Reset button colors
            redBtn.BackColor = Color.FromArgb(192, 0, 0);
            blackBtn.BackColor = Color.FromArgb(64, 64, 64);
            orangeBtn.BackColor = Color.FromArgb(255, 128, 0);
            redBtn.Size = new Size(100, 50);
            blackBtn.Size = new Size(100, 50);
            orangeBtn.Size = new Size(100, 50);

            // Highlight the selected button
            selectedButton.BackColor = Color.LightGray;
            selectedButton.Size = new Size(110, 60); // Slightly larger to indicate selection
        }

        private void buttonReset()
        {
            // Reset button states
            redBtn.BackColor = Color.FromArgb(192, 0, 0);
            blackBtn.BackColor = Color.FromArgb(64, 64, 64);
            orangeBtn.BackColor = Color.FromArgb(255, 128, 0);

            redBtn.Enabled = true;
            blackBtn.Enabled = true;
            orangeBtn.Enabled = true;
            startBtn.Enabled = true;

            redBtn.Size = new Size(100, 50);
            blackBtn.Size = new Size(100, 50);
            orangeBtn.Size = new Size(100, 50);
        }

        private void buttonDisable()
        {
            // Disable buttons during the race
            redBtn.Enabled = false;
            blackBtn.Enabled = false;
            orangeBtn.Enabled = false;
            startBtn.Enabled = false;
        }

        private void ResetCars()
        {
            // Reset the cars' positions visually
            car1.Location = new Point(15, 51);   // Match Y position in designer
            car2.Location = new Point(15, 178); // Match Y position in designer
            car3.Location = new Point(15, 304); // Match Y position in designer
        }

        private void car1_Click(object sender, EventArgs e)
        {

        }
    }
}