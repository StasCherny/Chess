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
                        

            Piece piece;   

            // can't move along a diagonal longer than one
            if (Math.Abs(destX - origX) > 1)
            {
                return false;
            }

            // can't move backward
            if (Color == SetColor.White)
            {
                if (origY > destY)
                {
                    return false;
                }
            }
            else    // color is Black
            {
                if (origY < destY)
                {
                    return false;
                }
            }
            

            if (IsFirstMove)
            {
                //for the first move can't move more than 2 cells
                if ( Math.Abs(destY - origY) > 2 )
                {
                    return false;
                }

                if (Math.Abs(destY - origY) == 2)
                {
                    // if the first move is 2 cells, can't jump over other piece
                    Board.Instance.CheckPiece(destX, (origY + destY)/2, out piece);
                    if(piece != null)
                    {
                        return false;
                    }
                }
            }
            else if(Math.Abs(destY - origY) != 1) // if isn't the first move - can move only for one call
            {
                return false;
            }

            if (Math.Abs(destX - origX) == 1)
            {
                // if going to remove other piece it must exist and be opposite color
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

            // TODO: pawn turns to another piece on the last row

            return true;
        }
    }
}
