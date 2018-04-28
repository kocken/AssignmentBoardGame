using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine
{
    public class TicTacToe : IGameEngine
    {
        private GameBoardTile[] GameTiles = new GameBoardTile[9];

        private List<string> Players = new List<string>();

        public TicTacToe()
        {
            int index = 0;
            for (int x = 0; 3 > x; x++)
            {
                for (int y = 0; 3 > y; y++)
                {
                    GameTiles[index] = new GameBoardTile(new Point(x, y), "");
                    index++;
                }
            }
        }

        public void PlaceMark(Mark mark, int index)
        {
            if (mark == Mark.Circle)
            {
                GameTiles[index].Mark = "O";
            }
            else
            {
                GameTiles[index].Mark = "X";
            }
        }

        public GameBoardTile[] GetGameTiles()
        {
            return GameTiles;
        }

        public List<string> GetPlayers()
        {
            return Players;
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

        public bool IsGameFull()
        {
            return Players.Count >= 2;
        }

        public void ResetGame()
        {
            Players.Clear();
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

    }
}
