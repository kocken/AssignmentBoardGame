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
            ResetBoard();
        }

        public void PlaceMark(Mark mark, int index)
        {
            GameTiles[index].Mark = mark == Mark.Circle ? "O" : "X";
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
            ResetBoard();
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

        private void ResetBoard()
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

    }
}
