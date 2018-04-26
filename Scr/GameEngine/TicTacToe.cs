using System;
using System.Collections;
using System.Collections.Generic;

namespace GameEngine
{
    public class TicTacToe : IGameEngine
    {
        private List<string> Players = new List<string>();

        public void AddPlayer(string name)
        {
            Players.Add(name);
        }

        public void RemovePlayer(string name)
        {
            Players.Remove(name);
        }

        public List<string> GetPlayers()
        {
            return Players;
        }
    }
}
