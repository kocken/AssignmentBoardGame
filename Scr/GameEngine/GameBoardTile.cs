using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngine
{
    public class GameBoardTile
    {
        public Point Coordinate { get; set; }
        public Mark Mark { get; set; }

        public GameBoardTile(Point coordinate, Mark mark)
        {
            this.Coordinate = coordinate;
            this.Mark = mark;
        }
    }
}
