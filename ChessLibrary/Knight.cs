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

        public override void MoveValidation(Cell origCell, Cell destCell)
        {
            // base validation
            base.MoveValidation(origCell, destCell);

            if (Math.Abs(origCell.X - destCell.X) == 2 && Math.Abs(origCell.Y - destCell.Y) == 1)
            {
                return;
            }

            if (Math.Abs(origCell.Y - destCell.Y) == 2 && Math.Abs(origCell.X - destCell.X) == 1)
            {
                return;
            }
            
            throw new MovePieceException(this.ToString() + " can't move this way");
            
        }
    }
}
