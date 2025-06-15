using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Cell : Button
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int NeighborMines { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            IsMine = false;
            IsRevealed = false;
            IsFlagged = false;
            NeighborMines = 0;

            // Set button properties
            Width = 40;
            Height = 40;
            FlatStyle = FlatStyle.Flat;
            Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            Text = "";
        }

        public void Reveal()
        {
            if (IsRevealed || IsFlagged) return;

            IsRevealed = true;
            if (IsMine)
            {
                Text = "💣";
                BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (NeighborMines > 0)
                {
                    Text = NeighborMines.ToString();
                    // Set different colors for different numbers
                    switch (NeighborMines)
                    {
                        case 1: ForeColor = System.Drawing.Color.Blue; break;
                        case 2: ForeColor = System.Drawing.Color.Green; break;
                        case 3: ForeColor = System.Drawing.Color.Red; break;
                        case 4: ForeColor = System.Drawing.Color.DarkBlue; break;
                        case 5: ForeColor = System.Drawing.Color.DarkRed; break;
                        case 6: ForeColor = System.Drawing.Color.DarkCyan; break;
                        case 7: ForeColor = System.Drawing.Color.Black; break;
                        case 8: ForeColor = System.Drawing.Color.Gray; break;
                    }
                }
                else
                {
                    Text = "";
                }
                BackColor = System.Drawing.Color.FromArgb(200, 200, 200); // More gray
            }
        }

        public void ToggleFlag()
        {
            if (!IsRevealed)
            {
                IsFlagged = !IsFlagged;
                Text = IsFlagged ? "🚩" : "";
                if (IsFlagged)
                {
                    BackColor = System.Drawing.Color.FromArgb(220, 220, 220); // Slightly gray for flagged
                }
                else
                {
                    BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }
    }
} 