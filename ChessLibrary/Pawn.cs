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

        public override bool IsMoveValid(Cell origCell, Cell destCell)
        {
            // base validation
            if (!base.IsMoveValid(origCell, destCell))
            {
                return false;
            }
                        

            Piece piece;   

            // can't move along a diagonal longer than one
            if (Math.Abs(destCell.X - origCell.X) > 1)
            {
                return false;
            }

            // can't move backward
            if (Color == SetColor.White)
            {
                if (origCell.Y > destCell.Y)
                {
                    return false;
                }
            }
            else    // color is Black
            {
                if (origCell.Y < destCell.Y)
                {
                    return false;
                }
            }
            

            if (IsFirstMove)
            {
                //for the first move can't move more than 2 cells
                if ( Math.Abs(destCell.Y - origCell.Y) > 2 )
                {
                    return false;
                }

                if (Math.Abs(destCell.Y - origCell.Y) == 2)
                {
                    // if the first move is 2 cells, can't jump over other piece
                    Cell newCell = new Cell(destCell.X, (origCell.Y + destCell.Y) / 2);                    
                    Board.Instance.CheckPiece(newCell, out piece);
                    if(piece != null)
                    {
                        return false;
                    }
                }
            }
            else if(Math.Abs(destCell.Y - origCell.Y) != 1) // if isn't the first move - can move only for one call
            {
                return false;
            }

            if (Math.Abs(destCell.X - origCell.X) == 1)
            {
                // if going to remove other piece it must exist and be opposite color
                Board.Instance.CheckPiece(destCell, out piece);
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
