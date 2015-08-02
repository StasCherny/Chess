using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Queen : Piece
    {
        public Queen(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Queen", Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}Q ", (Color == SetColor.White) ? "w" : "b");
        }

        public override bool IsMoveValid(int origX, int origY, int destX, int destY)
        {
            throw new NotImplementedException();
        }
    }
}
