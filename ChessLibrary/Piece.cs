using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public abstract class Piece
    {
        public Piece(SetColor color)
        {
            Color = color;
        }

        public SetColor Color { get; set; }
        public abstract string ToShortString();
        public virtual void MoveValidation(Cell origCell, Cell destCell)
        {
            Piece piece = Board.Instance.CheckPiece(destCell);

            // a piece cannot be moved to the same cell
            if (origCell == destCell)
            {
                throw new MovePieceException("You can't move a piece to the same cell");
            }

            // a piece of the same color cannot be removed
            if (piece != null && piece.Color == this.Color)
            {
                throw new MovePieceException("You can't remove a piece of the same color");
            }
                      
        }
    }
}
