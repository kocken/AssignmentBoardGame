﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine
{
    public class TicTacToe : IGameEngine
    {
        private List<string> Players = new List<string>();

        private GameBoardTile[] GameTiles = new GameBoardTile[9];

        public TicTacToe()
        {
            for (int x = 0; 3 > x; x++)
            {
                for (int y = 0; 3 > y; y++)
                {
                    GameTiles[x+y] = new GameBoardTile(new Point(x, y), null);
                }
            }
        }

        public string GetOpponentName(string playerName)
        {
            foreach (string name in Players)
            {
                if (!name.Equals(playerName))
                {
                    return name;
                }
            }
            return null;
        }

        public bool IsGameFull()
        {
            return Players.Count >= 2;
        }

        public void AddPlayer(string name)
        {
            if (!IsGameFull())
            {
                Players.Add(name);
            }
            else
            {
                throw new ArgumentException("Game is already full");
            }
        }

        public void RemovePlayer(string name)
        {
            Players.Remove(name);
        }

        public List<string> GetPlayers()
        {
            return Players;
        }

        public void ResetGame()
        {
            Players.Clear();
        }
    }
}
