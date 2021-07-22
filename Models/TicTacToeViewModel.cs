using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M8_Tic_Tac_Toe.Models
{
    public class TicTacToeViewModel
    {
        //get and set a list of cells
        public List<Cell> Cells { get; set; }
        //get and set cell as selected
        public Cell Selected { get; set; }
        //get and set a bool as to be called IsGameOver
        public bool IsGameOver { get; set; }
    }
}
