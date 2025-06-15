using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Board
    {
        public Cell[,] Grid { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int MineCount { get; private set; }
        public bool GameOver { get; set; }
        public bool FirstClick { get; private set; }

        private Random random;

        public Board(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
            Grid = new Cell[rows, columns];
            random = new Random();
            FirstClick = true;
            GameOver = false;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Grid[row, col] = new Cell(row, col);
                }
            }
        }

        public void PlaceMines(int firstClickRow, int firstClickCol)
        {
            int minesPlaced = 0;
            while (minesPlaced < MineCount)
            {
                int row = random.Next(Rows);
                int col = random.Next(Columns);

                // Don't place mine on first click or adjacent cells
                if (Math.Abs(row - firstClickRow) <= 1 && Math.Abs(col - firstClickCol) <= 1)
                    continue;

                if (!Grid[row, col].IsMine)
                {
                    Grid[row, col].IsMine = true;
                    minesPlaced++;
                }
            }

            // Calculate neighbor mines for each cell
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (!Grid[row, col].IsMine)
                    {
                        Grid[row, col].NeighborMines = CountNeighborMines(row, col);
                    }
                }
            }
        }

        private int CountNeighborMines(int row, int col)
        {
            int count = 0;
            for (int r = Math.Max(0, row - 1); r <= Math.Min(Rows - 1, row + 1); r++)
            {
                for (int c = Math.Max(0, col - 1); c <= Math.Min(Columns - 1, col + 1); c++)
                {
                    if (Grid[r, c].IsMine)
                        count++;
                }
            }
            return count;
        }

        public void RevealCell(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns || Grid[row, col].IsRevealed)
                return;

            if (FirstClick)
            {
                PlaceMines(row, col);
                FirstClick = false;
            }

            Grid[row, col].Reveal();

            if (Grid[row, col].IsMine)
            {
                GameOver = true;
                RevealAllMines();
                return;
            }

            // If cell has no neighboring mines, reveal neighbors
            if (Grid[row, col].NeighborMines == 0)
            {
                for (int r = Math.Max(0, row - 1); r <= Math.Min(Rows - 1, row + 1); r++)
                {
                    for (int c = Math.Max(0, col - 1); c <= Math.Min(Columns - 1, col + 1); c++)
                    {
                        if (!Grid[r, c].IsRevealed)
                            RevealCell(r, c);
                    }
                }
            }
        }

        private void RevealAllMines()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Grid[row, col].IsMine)
                        Grid[row, col].Reveal();
                }
            }
        }

        public bool CheckWin()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (!Grid[row, col].IsMine && !Grid[row, col].IsRevealed)
                        return false;
                }
            }
            return true;
        }
    }
} 