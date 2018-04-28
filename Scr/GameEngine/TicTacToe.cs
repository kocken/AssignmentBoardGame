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

        public string LastActivePlayer;

        public TicTacToe()
        {
            ResetBoard();
            Players = new List<string>();
        }

        public void PlaceMark(string name, Mark mark, int index)
        {
            LastActivePlayer = name;
            GameTiles[index].Mark = mark;  
        }

        public string GetPlayerTurn()
        {
            return GetMovesExecuted() % 2 == 0 ? Players[0] : Players[1];
        }

        public bool IsGameFinished() // if three of the same mark is in a line
        {
            foreach (GameBoardTile tile in GameTiles)
            {
                if (tile.Mark == Mark.Available)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPlayerOne(string name)
        {
            return name == Players[0];
        }

        public bool IsGameFull()
        {
            return Players.Count >= 2;
        }

        public bool IsGameWon() // if three of the same mark is in a line
        {
            if (MarkAt(1, 1) != Mark.Available && // if diagonal line with three in a row of the same mark
                (MarkAt(1, 1) == MarkAt(0, 2) && MarkAt(1, 1) == MarkAt(2, 0) || MarkAt(1, 1) == MarkAt(2, 2) && MarkAt(1, 1) == MarkAt(0, 0)))
            {
                return true;
            }
            for (int i = 0; 3 > i; i++)
            {
                if (MarkAt(i, 0) != Mark.Available && MarkAt(i, 0) == MarkAt(i, 1) && MarkAt(i, 0) == MarkAt(i, 2) ||
                    MarkAt(0, i) != Mark.Available && MarkAt(0, i) == MarkAt(1, i) && MarkAt(0, i) == MarkAt(2, i))
                {
                    return true;
                }
            }
            return false;
        }

        private Mark MarkAt(int x, int y)
        {
            foreach (GameBoardTile tile in GameTiles)
            {
                if (tile.Coordinate.X == x & tile.Coordinate.Y == y)
                {
                    return tile.Mark;
                }
            }
            return Mark.Available;
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
            for (int y = 2; y >= 0; y--)
            {
                for (int x = 0; 3 > x; x++)
                {
                    GameTiles[index] = new GameBoardTile(new Point(x, y), Mark.Available);
                    index++;
                }
            }
        }

        private int GetMovesExecuted()
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
}
