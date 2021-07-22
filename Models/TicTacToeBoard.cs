using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M8_Tic_Tac_Toe.Models
{
    public class TicTacToeBoard
    {
        //get and set a list of cells
        List<Cell>cells { get; set; }
        public TicTacToeBoard()
        {
            //sets the rows to be labled top, middle and bottom and the cols to be left, middle and right.
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };
            //sets cells to be the list of cell
            cells = new List<Cell>();
            //foreach to loop through cols and rows
            foreach (string r in rows)
            {
                foreach (string c in cols)
                {
                    Cell cell = new Cell { Id = r + c };
                    cells.Add(cell);
                }
            }
        }
        //get cells from the list cells
        public List<Cell> GetCells() => cells;
        //get and set a bool as has winner
        public bool HasWinner { get; set; }
        //get and set the winning mark
        public string WinningMark { get; set; }
        //get and set a bool as has all cells selected
        public bool HasAllCellSelected { get; set; }
        /// <summary>
        /// method to check for the winner
        /// </summary>
        public void CheckForWinner()
        {
            //initially there is no winner so its false
            HasWinner = false;
            WinningMark = null;
            //checks for top row win
            if (IsWinner(cells[0].Mark, cells[1].Mark, cells[2].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //checks for left column win
            else if (IsWinner(cells[0].Mark, cells[3].Mark, cells[6].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //checks for diagonal win
            else if (IsWinner(cells[0].Mark, cells[4].Mark, cells[8].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //checks for middle row win
            else if (IsWinner(cells[3].Mark, cells[4].Mark, cells[5].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[3].Mark;
            }
            //checks for bottom row win
            else if (IsWinner(cells[6].Mark, cells[7].Mark, cells[8].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[6].Mark;
            }
            //checks for middle column win
            else if (IsWinner(cells[1].Mark, cells[4].Mark, cells[7].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[1].Mark;
            }
            //checks for right column win
            else if (IsWinner(cells[2].Mark, cells[5].Mark, cells[8].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }
            //checks for the other diagonal win
            else if (IsWinner(cells[2].Mark, cells[4].Mark, cells[6].Mark))
            {
                //if all those cells are marked then there is a winner and they are announced.
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }
            //checks if every cell is selected
            HasAllCellSelected = true;
            //foreach loop to check if the cells are blank
            foreach (Cell cell in cells)
            {
                if (cell.IsBlank)
                {
                    HasAllCellSelected = false;
                    return;
                }
            }
        }
        /// <summary>
        /// method for the winning marks
        /// </summary>
        /// <param name="mark1"></param>
        /// <param name="mark2"></param>
        /// <param name="mark3"></param>
        /// <returns></returns>
        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }
    }
}
