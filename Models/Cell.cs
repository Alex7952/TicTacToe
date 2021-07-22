using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M8_Tic_Tac_Toe.Models
{
    public class Cell
    {
        //get and set the id
        public string Id { get; set; }
        //get and set the mark
        public string Mark { get; set; }
        //set the isbnlank to check if its null or empty
        public bool IsBlank => string.IsNullOrEmpty(Mark);
        //if the cell name returns as Right then it will bump the cells down a row to create three rows in all
        public bool IsEndCell => Id.EndsWith("Right");
    }
}
