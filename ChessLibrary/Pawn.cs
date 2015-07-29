using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Pawn : Piece
    {
        public Pawn(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Pawn",Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}P ", (Color == SetColor.White) ? "w" : "b");
        }
    }
}
