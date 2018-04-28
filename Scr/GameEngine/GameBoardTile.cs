using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngine
{
    public class GameBoardTile
    {
        public Point Coordinate { get; set; }
        public string OccupiedBy { get; set; }

        public GameBoardTile(Point coordinate, string occupiedBy)
        {
            this.Coordinate = coordinate;
            this.OccupiedBy = occupiedBy;
        }
    }
}
