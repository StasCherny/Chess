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
        public virtual bool IsMoveValid(Cell origCell, Cell destCell)
        {
            Piece piece;
            Board.Instance.CheckPiece(destCell, out piece);

            // a piece of the same color cannot be removed
            if (piece != null && piece.Color == this.Color)
            {
                return false;
            }
            // a piece cannot be moved to the same cell
            if (origCell.X == destCell.X && origCell.Y == destCell.Y)
            {
                return false;
            }

            return true;
        }
    }
}
