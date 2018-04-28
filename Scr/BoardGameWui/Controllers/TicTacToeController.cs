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

        private static TicTacToe Game = new TicTacToe();

        private static string CookieName = "PlayerName";

        public ActionResult Index()
        {
            PlayerModel model = GetPlayerModel();
            if (model.Name != null)
            {
                return View("Game", model);
            }
            else
            {
                return View("Lobby");
            }
        }

        public ActionResult JoinLobby(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(model.Name);
            }
            else
            {
                TempData["notice"] = "You need to enter a valid name.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult LeaveGame(PlayerModel model)
        {
            Game.RemovePlayer(model.Name);
            ClearPlayerCookie();
            TempData["notice"] = "Player \"" + model.Name + "\" left the game.";
            return RedirectToAction("Index");
        }

        public ActionResult ResetGame()
        {
            Game.ResetGame();
            TempData["notice"] = "The game was reset.";
            return RedirectToAction("Index");
        }

        private PlayerModel GetPlayerModel()
        {
            PlayerModel model = new PlayerModel();
            string playerName = GetPlayerCookieName();
            if (playerName != null)
            {
                if (!Game.GetPlayers().Any(n => n.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))) // if cookie name isn't in game (due to restart)
                {
                    if (!Game.IsGameFull())
                    {
                        AddPlayer(playerName);
                    }
                    else // clear cookie if the game is full and player isn't in it
                    {
                        ClearPlayerCookie();
                    }
                }
                if (Game.GetPlayers().Any(n => n.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))) // if cookie name is in game
                {
                    model.Name = playerName;
                }
            }
            return model;
        }

        private void AddPlayer(string name)
        {
            string startStr = "";
            if (TempData["notice"] != null)
            {
                startStr = TempData["notice"] + " " + "<br />"; // will be used if the game was reset and player has a cookie, to show both reset + join messages
            }
            if (!Game.GetPlayers().Any(n => n.Equals(name, StringComparison.InvariantCultureIgnoreCase))) // if player name isn't taken
            {
                if (!Game.IsGameFull())
                {
                    Game.AddPlayer(name);
                    StorePlayerCookie(name);
                    TempData["notice"] = startStr + "Player \"" + name + "\" joined the game.";
                }
                else
                {
                    TempData["notice"] = startStr + "The max limit of players have been reached. Feel free to reset the game.";
                }
            }
            else
            {
                TempData["notice"] = startStr + "Player name \"" + name + "\" is already taken.";
            }
        }

        private string GetPlayerCookieName()
        {
            if (Request.Cookies[CookieName] != null)
            {
                return Request.Cookies[CookieName].Value;
            }
            return null;
        }

        private void StorePlayerCookie(string name)
        {
            HttpCookie playerCookie = new HttpCookie(CookieName);
            playerCookie.Value = name;
            playerCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(playerCookie);
        }

        private void ClearPlayerCookie()
        {
            if (Request.Cookies[CookieName] != null)
            {
                Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}