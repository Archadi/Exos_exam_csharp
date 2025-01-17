﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Lib
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Set(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Boolean Equals(Point p)
        {
            return p.X == X && p.Y == Y;
        }

        public override string ToString()
        {
            return String.Format("Point (X: {0}, Y: {1})", X, Y);
        }
    }
}
