using BoardGameWui.Models;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameWui.Controllers
{
    public class TicTacToeController : Controller
    {

        TicTacToe Game = new TicTacToe();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new GameModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Game.GetPlayers().Any(name => name.Equals(model.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    Game.AddPlayer(model.Name);
                    StorePlayerCookie(model.Name);
                    TempData["notice"] = "Player " + model.Name + " joined the game." + " " + string.Join(",", Game.GetPlayers().ToArray());
                }
                else
                {
                    TempData["notice"] = "Player name \"" + model.Name + "\" is already taken.";
                }
            }
            else
            {
                TempData["notice"] = "You need to enter a valid name.";
            }
            return RedirectToAction("Index");
        }

        private void StorePlayerCookie(string name)
        {
            HttpCookie playerCookie = new HttpCookie("PlayerName");
            playerCookie.Value = name;
            playerCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(playerCookie);
        }
    }
}