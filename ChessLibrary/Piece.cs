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
        public virtual bool IsMoveValid(int origX, int origY, int destX, int destY)
        {
            Piece piece;
            Board.Instance.CheckPiece(destX, destY, out piece);

            // a piece of the same color cannot be removed
            if (piece != null && piece.Color == this.Color)
            {
                return false;
            }
            // a piece cannot be moved to the same cell
            if (origX == destX && origX == destX)
            {
                return false;
            }

            return true;
        }
    }
}
