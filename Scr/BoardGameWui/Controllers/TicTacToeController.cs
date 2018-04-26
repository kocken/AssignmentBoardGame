using BoardGameWui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameWui.Controllers
{
    public class TicTacToeController : Controller
    {
        // GET: TicTacToe
        public ActionResult Index()
        {
            var model = new GameModel();
            model.Message = "Welcome to my Tic-Tac-Toe game. Play below with a friend using a secondary browser and try get three in a row!";
            return View(model);
        }
    }
}