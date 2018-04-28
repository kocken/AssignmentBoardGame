using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine
{
    public class TicTacToe : IGameEngine
    {
        public GameBoardTile[] GameTiles { get; private set; }

        public List<string> Players { get; private set; }

        public int MovesExecuted
        {
            get
            {
                int moves = 0;
                foreach (GameBoardTile tile in GameTiles)
                {
                    if (tile.Mark != Mark.Available)
                    {
                        moves++;
                    }
                }
                return moves;
            }
        }

        public TicTacToe()
        {
            ResetBoard();
            Players = new List<string>();
        }

        public void PlaceMark(Mark mark, int index)
        {
            GameTiles[index].Mark = mark;
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
            GameTiles = new GameBoardTile[9];
            int index = 0;
            for (int x = 0; 3 > x; x++)
            {
                for (int y = 0; 3 > y; y++)
                {
                    GameTiles[index] = new GameBoardTile(new Point(x, y), Mark.Available);
                    index++;
                }
            }
        }

    }
}
