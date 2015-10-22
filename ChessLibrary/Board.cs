using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Board
    {
        private static int sizeX = 8;
        private static int sizeY = 8;
        private static Board instance = new Board();
        private Piece[,] BoardOfPieces = new Piece[sizeX,sizeY];

        public Dictionary<char, int> LetterToNumber = new Dictionary<char, int>();
        public Dictionary<int, char> NumberToLetter = new Dictionary<int, char>();
                
        public int MaxX   { get { return sizeX - 1 ; } }
        public int MaxY { get { return sizeY - 1; } }
        public int MinX { get { return 0; } }
        public int MinY { get { return 0; } }

        private Board()
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            for (int i = 0; i < letters.Length; i++)
            {
                LetterToNumber.Add(letters[i], i + 1);
                NumberToLetter.Add(i + 1, letters[i]);
            }
        }

        public static Board Instance
        {            
            get
            {
                return instance;
            }            
        }


        private void CheckBoarders(Cell cell)
        {
            if (cell.X > MaxX || cell.Y > MaxY || cell.X < MinX || cell.Y < MinY)
            {
                throw new BoardException("The cell is out of the board borders");
            }
        }

        private void CheckBoarders(Cell origCell, Cell destCell)
        {
            CheckBoarders(origCell);
            CheckBoarders(destCell);
        }
        public void Reset()
        {
            Array.Clear(BoardOfPieces,0,BoardOfPieces.Length);
        }

        public void PlacePiece(Piece newPiece, Cell cell)
        {
            if (newPiece == null)
            {
                throw new BoardException("Can't place a piece that is null");
            }

            CheckBoarders(cell);

            BoardOfPieces[cell.X, cell.Y] = newPiece;
            newPiece.CurrentCell = cell;            
        }

        public Piece CheckPiece(Cell cell)
        {
            CheckBoarders(cell);

            return BoardOfPieces[cell.X, cell.Y];
        }

        
        public Piece MovePiece(Piece newPiece, Cell origCell, Cell destCell)
        {
            if (newPiece == null)
            {
                throw new BoardException("Can't place a piece that is null");
            }

            CheckBoarders(origCell, destCell);

            newPiece.MoveValidation(origCell, destCell);    // will throw exception on error            
            Piece oldPiece = CheckPiece(destCell);
            PlacePiece(newPiece, destCell);
            BoardOfPieces[origCell.X, origCell.Y] = null;  // remove the piece from original cell

            // if opponents piece has been removed - clear its cell
            if (oldPiece != null)
                oldPiece.CurrentCell = new Cell(-1,-1);
            return oldPiece;
        }
             

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 7; i >= 0; i-- )
            {
                sb.AppendFormat("{0}   ",i+1);
                for (int j = 0; j < 8; j++)
                {
                    sb.Append((BoardOfPieces[j, i] == null) ? "x   " : BoardOfPieces[j, i].ToShortString() + " ");
                }
                sb.AppendLine();
            }
            
            sb.AppendLine();
            sb.Append("    ");
            for (int i = 0; i < 8; i++)
            {
                sb.AppendFormat("{0}   ", NumberToLetter[i + 1]);
            }
            sb.AppendLine();
            return sb.ToString();
            
        }

        public bool IsLine(Cell origCell,Cell destCell)
        {
            if (origCell.X == destCell.X && origCell.Y != destCell.Y)
            {
                return true;
            }

            if (origCell.Y == destCell.Y && origCell.X != destCell.X)
            {
                return true;
            }

            return false;
        }

        public int GetNumberOfPiecesOnLine(Cell origCell, Cell destCell)
        {
            int PiecesCount = 0;
            // vertical line
            if (origCell.X == destCell.X && origCell.Y != destCell.Y)
            {
                int length = Math.Abs(destCell.Y - origCell.Y) + 1;
                Cell checkCell = new Cell(
                                    origCell.X,
                                    (origCell.Y < destCell.Y) ? origCell.Y : destCell.Y
                                    );                

                for (int i = 0; i < length; i++, checkCell.Y++)
                {                     
                    if (Board.Instance.CheckPiece(checkCell) != null)
                    {
                        PiecesCount++;
                    }
                }
            }
            else if(origCell.Y == destCell.Y && origCell.X != destCell.X)   // horizontal line
            {
                int length = Math.Abs(destCell.X - origCell.X) + 1;
                Cell checkCell = new Cell(
                                     (origCell.X < destCell.X) ? origCell.X : destCell.X,
                                     origCell.Y
                                    );                

                for (int i = 0; i < length; i++,checkCell.X++)
                {
                    if (Board.Instance.CheckPiece(checkCell) != null)
                    {
                        PiecesCount++;
                    }
                }
            }           

            return PiecesCount;
        }

        public bool IsDiagonal(Cell origCell, Cell destCell)
        {
            if (origCell != destCell && (Math.Abs(origCell.X - destCell.X) == Math.Abs(origCell.Y - destCell.Y)))
            {
                return true;
            }
            return false;
        }

        public int GetNumberOfPiecesOnDiagonal(Cell origCell, Cell destCell)
        {
            int PiecesCount = 0;

            if (IsDiagonal(origCell,destCell))
            {
                int length = Math.Abs(origCell.X - destCell.X) + 1;
                int stepX = (origCell.X < destCell.X) ? 1 : -1;
                int stepY = (origCell.Y < destCell.Y) ? 1 : -1;
                Cell checkCell = origCell;
                for (int i = 0; i < length; i++)
                {
                    if (Board.Instance.CheckPiece(checkCell) != null)
                    {
                        PiecesCount++;
                    }
                    checkCell.X += stepX;
                    checkCell.Y += stepY;
                }
            }

            return PiecesCount;
        }

        public void TrackState()
        {

        }

        public void UndoTrakedState(int count)
        {

        }
    }
}
