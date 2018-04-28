using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public interface IGameEngine
    {
        List<string> Players { get; }

        bool IsGameFinished();
        bool IsGameWon();
        bool IsGameFull();
        void AddPlayer(string name);
        void RemovePlayer(string name);
        void ResetGame();
    }
}
