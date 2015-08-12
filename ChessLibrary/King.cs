using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class King : Piece
    {
        public King(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} King", Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}K ", (Color == SetColor.White) ? "w" : "b");
        }

        public override bool IsMoveValid(Cell origCell, Cell destCell)
        {
            throw new NotImplementedException();
        }
    }
}
