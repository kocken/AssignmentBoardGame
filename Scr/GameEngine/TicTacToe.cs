using System;
using System.Collections;
using System.Collections.Generic;

namespace GameEngine
{
    public class TicTacToe : IGameEngine
    {
        private List<string> Players = new List<string>();

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
