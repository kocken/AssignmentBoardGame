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

        [HttpGet]
        public ActionResult Index()
        {
            var model = new GameModel();
            model.Message = "Welcome to my Tic-Tac-Toe game. Play below with a friend and try get three in a row! " +
                "You need to play the game on the same computer, use two different browsers and play on one browser each.";
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Player model)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(model.Name);
                TempData["notice"] = "Player " + model.Name + " joined the game.";
            }
            else
            {
                TempData["notice"] = "You need to enter a valid name.";
            }
            return RedirectToAction("Index");
        }

        private void AddPlayer(string name)
        {

        }
    }
}