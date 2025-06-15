using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private Board gameBoard;
        private const int GRID_SIZE = 10;
        private const int MINE_COUNT = 10;
        private const int CELL_SIZE = 40;
        private const int GRID_TOP_MARGIN = 10;
        private const int GRID_LEFT_MARGIN = 10;
        private const int BUTTON_HEIGHT = 40;
        private const int BUTTON_MARGIN = 10;

        public Form1()
        {
            InitializeComponent();
            btnRestart.Click += BtnRestart_Click;
            InitializeGame();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Clear only the grid cells, not the restart button
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is Cell)
                    Controls.RemoveAt(i);
            }

            // Create new game board
            gameBoard = new Board(GRID_SIZE, GRID_SIZE, MINE_COUNT);

            // Add cells to form
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    Cell cell = gameBoard.Grid[row, col];
                    cell.Location = new System.Drawing.Point(
                        GRID_LEFT_MARGIN + col * CELL_SIZE,
                        GRID_TOP_MARGIN + row * CELL_SIZE
                    );
                    cell.Click += Cell_Click;
                    cell.MouseUp += Cell_MouseUp;
                    Controls.Add(cell);
                }
            }

            // Place the restart button below the grid
            btnRestart.Location = new System.Drawing.Point(
                GRID_LEFT_MARGIN,
                GRID_TOP_MARGIN + GRID_SIZE * CELL_SIZE + BUTTON_MARGIN
            );
            btnRestart.Size = new System.Drawing.Size(100, BUTTON_HEIGHT);

            // Set form size to fit grid and button
            ClientSize = new System.Drawing.Size(
                Math.Max(GRID_LEFT_MARGIN * 2 + GRID_SIZE * CELL_SIZE, 120),
                GRID_TOP_MARGIN + GRID_SIZE * CELL_SIZE + BUTTON_MARGIN + BUTTON_HEIGHT + 10
            );
            Text = "Minesweeper";
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (gameBoard.GameOver) return;

            Cell clickedCell = (Cell)sender;
            gameBoard.RevealCell(clickedCell.Row, clickedCell.Column);

            if (gameBoard.GameOver)
            {
                MessageBox.Show("Game Over! You hit a mine!", "Minesweeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gameBoard.CheckWin())
            {
                MessageBox.Show("Congratulations! You won!", "Minesweeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameBoard.GameOver = true;
            }
        }

        private void Cell_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Cell clickedCell = (Cell)sender;
                if (!clickedCell.IsRevealed)
                {
                    clickedCell.ToggleFlag();
                }
            }
        }
    }
}
