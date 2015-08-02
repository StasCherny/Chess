using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public abstract class Piece
    {
        public Piece(SetColor color)
        {
            Color = color;
        }

        public SetColor Color { get; set; }
        public abstract string ToShortString();
        public abstract bool IsMoveValid(int origX, int origY,int destX, int destY);
    }
}
