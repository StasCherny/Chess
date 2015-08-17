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

        public override void MoveValidation(Cell origCell, Cell destCell)
        {
            base.MoveValidation(origCell, destCell);

            // check if is moving along a line
            if (!Board.Instance.IsLine(origCell,destCell))
            {
                throw new MovePieceException(this.ToString() + " can move only along a line");
            }

            // check if no other piece on the way

        }
    }
}
