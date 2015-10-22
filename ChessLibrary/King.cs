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

        public bool IsUnderCheck(Cell cell)
        {
            Board board = Board.Instance;
            Piece checkPiece;           

            #region up right diagonal
            Cell checkCell = cell;                        
            // scan a up right diagonal
            while (checkCell.X < board.MaxX && checkCell.Y < board.MaxY)
            {
                checkCell.Increment();
                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;
                
                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;
                
                if (checkPiece is Bishop || checkPiece is Queen)    // only bishop or queen are threat on the whole diagonal                
                    return true;                

                if (Math.Abs(checkCell.X - cell.X) == 1 && Math.Abs(checkCell.Y - cell.Y) == 1)    // on next cell on a diagonal
                {
                    if (checkPiece is Pawn)
                    {
                        // for white pieces pawn from the up direction is check
                        if (this.Color == SetColor.White)                        
                            return true;                        
                    }
                    else if (checkPiece is King)                    
                        return true;                    
                }                                                                   
            }
            #endregion

            #region down left diagonal
            checkCell = cell;
            // scan a down left diagonal
            while (checkCell.X > board.MinX && checkCell.Y > board.MinY)
            {
                checkCell.Decriment();
                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Bishop || checkPiece is Queen)    // only bishop or queen are threat on the whole diagonal                
                    return true;

                if (Math.Abs(checkCell.X - cell.X) == 1 && Math.Abs(checkCell.Y - cell.Y) == 1)    // on next cell on a diagonal
                {
                    if (checkPiece is Pawn)
                    {
                        // for black pieces pawn from the down direction is check
                        if (this.Color == SetColor.Black)
                            return true;
                    }
                    else if (checkPiece is King)
                        return true;
                }                
            }
            #endregion

            #region up left diagonal
            checkCell = cell;
            // scan a up left diagonal
            while (checkCell.X > board.MinX && checkCell.Y < board.MaxY)
            {
                checkCell.X--;
                checkCell.Y++;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Bishop || checkPiece is Queen)    // only bishop or queen are threat on the whole diagonal                
                    return true;

                if (Math.Abs(checkCell.X - cell.X) == 1 && Math.Abs(checkCell.Y - cell.Y) == 1)    // on next cell on a diagonal
                {
                    if (checkPiece is Pawn)
                    {
                        // for white pieces pawn from the up direction is check
                        if (this.Color == SetColor.White)
                            return true;
                    }
                    else if (checkPiece is King)
                        return true;
                }                
            }
            #endregion

            #region down right diagonal
            checkCell = cell;
            // scan a down right diagonal
            while (checkCell.X < board.MaxX && checkCell.Y > board.MinY)
            {
                checkCell.X++;
                checkCell.Y--;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Bishop || checkPiece is Queen)    // only bishop or queen are threat on the whole diagonal                
                    return true;

                if (Math.Abs(checkCell.X - cell.X) == 1 && Math.Abs(checkCell.Y - cell.Y) == 1)    // on next cell on a diagonal
                {
                    if (checkPiece is Pawn)
                    {
                        // for black pieces pawn from the down direction is check
                        if (this.Color == SetColor.Black)
                            return true;
                    }
                    else if (checkPiece is King)
                        return true;
                }                
            }
            #endregion

            checkCell = cell;
            // scan a line left
            while (checkCell.X < board.MaxX)
            {
                checkCell.X++;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Rook || checkPiece is Queen)    // only rook or queen are threat on the whole line                
                    return true;
            }

            checkCell = cell;
            // scan a line right
            while (checkCell.X > board.MinX)
            {
                checkCell.X--;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Rook || checkPiece is Queen)    // only rook or queen are threat on the whole line                
                    return true;
            }

            checkCell = cell;
            // scan a line up
            while (checkCell.Y < board.MaxY)
            {
                checkCell.Y++;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Rook || checkPiece is Queen)    // only rook or queen are threat on the whole line                
                    return true;
            }

            checkCell = cell;
            // scan a line down
            while (checkCell.Y > board.MinY)
            {
                checkCell.Y--;

                checkPiece = board.CheckPiece(checkCell);
                if (checkPiece == null)  // no piece - no check
                    continue;

                if (checkPiece.Color == this.Color) // the same color - no check    
                    break;

                if (checkPiece is Rook || checkPiece is Queen)    // only rook or queen are threat on the whole line                
                    return true;
            }

            // check all 8 possible combination for knight
            Cell[] knightMoves = {  new Cell(2,1),
                                    new Cell(1,2),
                                    new Cell(-1,2),
                                    new Cell(-2,1),
                                    new Cell(-2,-1),
                                    new Cell(-1,-2),
                                    new Cell(1,-2),
                                    new Cell(2,-1)  };
            for (int i = 0; i < knightMoves.Length; i++)
            {
                checkCell = cell;
                checkCell.X += knightMoves[i].X;
                checkCell.Y += knightMoves[i].Y;
                if (checkCell.X > board.MaxX || checkCell.X < board.MinX || checkCell.Y > board.MaxY || checkCell.Y < board.MinY)
                {
                    continue;
                }
            }
            return false;
        }
    }
}
