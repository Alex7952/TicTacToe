using M8_Tic_Tac_Toe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M8_Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index()
        {
            //create board as a new board
            TicTacToeBoard board = new TicTacToeBoard();
            //call the list to get cells on the board
            List<Cell> cells = board.GetCells();
            //foreach loop to loop through cell id
            foreach (Cell cell in cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            //Check for winner
            board.CheckForWinner();
            //create the model
            TicTacToeViewModel model = new TicTacToeViewModel
            {
                //set Cells equal to cells and check for next turn
                Cells = cells,
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X"},
                //check if game over?
                IsGameOver = board.HasWinner || board.HasAllCellSelected
            };
            //message to tell you who won of it its a tie
            if (model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                TempData["message"] = (board.HasWinner) ? $"{board.WinningMark} wins!" : "It's a tie!";// find out if there is a winner else show tie
            }
            else
            {
                //keep the x's and o's on the board so the board doesnt keep reseting
                TempData.Keep();
            }
            //returns the view of the model
            return View(model);
        }
        /// <summary>
        /// redirects to the index once the code is run in this method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel model)
        {
            //stores the selected cell
            TempData[model.Selected.Id] = model.Selected.Mark;
            //say who is the next to go. determine if there is an X, if yes then O goes, else keep X
            TempData["nextTurn"] = model.Selected.Mark == "X" ? "O" : "X";
            return RedirectToAction("Index");
        }
    }
}
