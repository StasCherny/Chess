﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public struct Cell
    {
        public int X;
        public int Y;
                
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
      
        public static Cell operator --(Cell cell)
        {
            return new Cell(cell.X - 1, cell.Y - 1);
        }

        public static Cell operator ++(Cell cell)
        {
            return new Cell(cell.X + 1, cell.Y + 1);
        }

        public static bool operator == (Cell a,Cell b)
        {        
            return (a.X == b.X && a.Y == b.Y);
        }

        public static bool operator !=(Cell a, Cell b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Cell)
            {
                return this == (Cell)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (this.X * this.Y).GetHashCode();
        }
    }
}