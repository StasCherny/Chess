using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Bishop : Piece
    {
        public Bishop(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Bishop", Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}B ", (Color == SetColor.White) ? "w" : "b");
        }
    }
}
