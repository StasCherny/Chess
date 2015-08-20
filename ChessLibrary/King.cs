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

        public override void MoveValidation(Cell origCell, Cell destCell)
        {
            // base validation
            base.MoveValidation(origCell, destCell);

            // TODO: Check castling

            if (Math.Abs(origCell.X - destCell.X) != 1 && Math.Abs(origCell.Y - destCell.Y) != 1)
            {
                throw new MovePieceException(this.ToString() + " can move only by one cell");
            }

            // TODO: Check under check
        }
    }
}
