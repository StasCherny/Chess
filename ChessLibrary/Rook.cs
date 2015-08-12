using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Rook : Piece
    {
        public Rook(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Rook", Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}R ", (Color == SetColor.White)?"w":"b"); 
        }

        public override bool IsMoveValid(Cell origCell, Cell destCell)
        {
            throw new NotImplementedException();
        }
    }
}
