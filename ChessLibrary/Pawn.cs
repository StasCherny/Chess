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
            // base validation
            if (!base.IsMoveValid(origX, origY, destX, destY))
            {
                return false;
            }
            else if (origX == destX)    // can't remove a piece on the same column
            {
                return false;
            }

            // can't move backward
            if (destY < destX)
            {
                return false;
            }

            Piece piece;
            Board.Instance.CheckPiece(destX, destY, out piece);            
            

            // can't move along a diagonal longer than one
            if ((destX - origX) > 1 || (destX - origX) < -1)
            {
                return false;
            }
            
            if (IsFirstMove)
            {
                //for the first move can't move more than 2 cells
                if ( (destY - origY) > 2 )
                {
                    return false;
                }

                if ((destY - origY) == 2)
                {
                    // if the first move is 2 cells, can't jump over other piece
                    Board.Instance.CheckPiece(destX, destY - 1, out piece);
                    if(piece != null)
                    {
                        return false;
                    }
                }
            }
            else if(origY + 1 != destY) // if isn't the first move - can move only for one call
            {
                return false;
            }

            if ((destX - origX) == 1 || (destX - origX) == -1)
            {
                // if going to remove other piece it must exist and be of other color
                Board.Instance.CheckPiece(destX, destY, out piece);
                if (piece == null || piece.Color == this.Color)
                {
                    return false;
                }                
            }

            if (IsFirstMove)
            {
                IsFirstMove = false;
            }

            return true;
        }
    }
}
