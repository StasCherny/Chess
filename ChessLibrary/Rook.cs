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
            int numOfPieces = Board.Instance.GetNumberOfPiecesOnLine(origCell, destCell);
            // not a line
            if (numOfPieces == 0)
            {
                throw new MovePieceException(this.ToString() + " can move only along a line");
            }
            // check if no other piece on the way
            if (numOfPieces > 2)
            {
                throw new MovePieceException(this.ToString() + " can jump over an other piece");
            }

            if(numOfPieces == 2 && Board.Instance.CheckPiece(destCell) == null)
            {
                throw new MovePieceException(this.ToString() + " can jump over an other piece");
            }
        }
    }
}
