using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Knight : Piece
    {
        public Knight(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Knight", Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}Kn", (Color == SetColor.White) ? "w" : "b");
        }
    }
}
