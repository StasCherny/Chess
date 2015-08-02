using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Pawn : Piece
    {
        private bool IsFirstMove = true;

        public Pawn(SetColor color) : base(color) { }

        public override string ToString()
        {
            return String.Format("{0} Pawn",Color.ToString());
        }

        public override string ToShortString()
        {
            return String.Format("{0}P ", (Color == SetColor.White) ? "w" : "b");
        }

        public override bool IsMoveValid(int origX, int origY, int destX, int destY)
        {
            Piece piece;
            Board.Instance.CheckPiece(destX, destY, out piece);
            if (piece != null && piece.Color == this.Color)
            {
                return false;
            }
            else if (origX == destX)
            {
                return false;
            }

            //if (origX != destX || origX + 1 != destX || origX - 1 != destX )
            if ((destX - origX) > 1 || (destX - origX) < -1)
            {
                return false;
            }

            if (IsFirstMove)
            {
                //if (origY + 1 != destY || origY + 2 != destY)
                if ( (destY - origY) > 2 )
                {
                    return false;
                }

                if ((destY - origY) == 2)
                {
                    Board.Instance.CheckPiece(destX, destY - 1, out piece);
                    if(piece != null)
                    {
                        return false;
                    }
                }

                IsFirstMove = false;
            }
            else if(origY + 1 != destY)
            {
                return false;
            }

            if ((destX - origX) == 1 || (destX - origX) == -1)
            {
                Board.Instance.CheckPiece(destX, destY, out piece);
                if (piece == null || piece.Color == this.Color)
                {
                    return false;
                }                
            }

            return true;
        }
    }
}
