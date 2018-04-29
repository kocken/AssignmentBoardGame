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
        private static TicTacToe GameEngine = new TicTacToe();

        private static string CookieName = "PlayerName";

        public ActionResult Index()
        {
            GameSession session = GetPlayer();
            if (session.PlayerName != null)
            {
                session.OpponentName = GameEngine.GetOpponentName(session.PlayerName);
                if (session.OpponentName != null)
                {
                    session.GameTiles = GameEngine.GameTiles;
                    if (GameEngine.IsGameWon())
                    {
                        ViewBag.Winner = GameEngine.LastActivePlayer;
                        return View("GameOver", session);
                    }
                    else if (GameEngine.IsGameFinished())
                    {
                        return View("GameDraw", session);
                    }
                    else
                    {
                        session.MyTurn = GameEngine.GetPlayerTurn() == session.PlayerName;
                        return View("Game", session);
                    }
                }
                else
                {
                    return View("Lobby", session);
                }
            }
            else
            {
                return View("Lobby", session);
            }
        }
        
        public ActionResult JoinLobby(GameSession session)
        {
            if (ModelState.IsValid) // if PlayerName is valid (!= null & length > 0)
            {
                AddPlayer(session.PlayerName);
            }
            else
            {
                TempData["notice"] = "You need to enter a valid name.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ResetGame()
        {
            GameEngine.ResetGame();
            TempData["notice"] = "The game was reset.";
            return RedirectToAction("Index");
        }

        public ActionResult LeaveGame(string playerName)
        {
            GameEngine.RemovePlayer(playerName);
            ClearPlayerCookie();
            TempData["notice"] = "Player \"" + playerName + "\" left the game.";
            return RedirectToAction("Index");
        }

        public ActionResult PickTile(string playerName, int index)
        {
            GameEngine.PlaceMark(playerName, GameEngine.IsPlayerOne(playerName) ? Mark.X : Mark.O, index);
            return RedirectToAction("Index");
        }

        private GameSession GetPlayer()
        {
            GameSession session = new GameSession();
            string playerName = GetPlayerCookieName();
            if (playerName != null)
            {
                if (!GameEngine.Players.Any(n => n.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))) // if cookie name isn't in game (due to restart)
                {
                    if (!GameEngine.IsGameFull())
                    {
                        AddPlayer(playerName);
                    }
                    else // clear cookie if the game is full and player isn't in it
                    {
                        ClearPlayerCookie();
                    }
                }
                if (GameEngine.Players.Any(n => n.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))) // if cookie name is in game
                {
                    session.PlayerName = playerName;
                }
            }
            return session;
        }

        private void AddPlayer(string name)
        {
            string startStr = "";
            if (TempData["notice"] != null)
            {
                startStr = TempData["notice"] + " " + "<br />"; // will be used if the game was reset and player has a cookie, to show both reset + join messages
            }
            if (!GameEngine.Players.Any(n => n.Equals(name, StringComparison.InvariantCultureIgnoreCase))) // if player name isn't taken
            {
                if (!GameEngine.IsGameFull())
                {
                    GameEngine.AddPlayer(name);
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
            Response.Cookies.Set(playerCookie);
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