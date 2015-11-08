using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Player
    {
        private Board board = Board.Instance;        
        public King TheKing { get; private set; }
        private King theKing;

       
        // Constructor
        public Player(string name, SetColor setColor)
        {
            Name = name;
            Color = setColor;
            TheKing = null;

            SetPieces();            
        }

        public string Name { get; private set; }
        public SetColor Color { get; private set; }


        private void SetPieces()
        {            
            Cell cell = new Cell(0, 0);
            // Set pawns
            cell.Y = (Color == SetColor.White) ?  1 :  6;	        
            
            for (int i = 0; i < 8; i++)
            {
                cell.X = i;
                board.PlacePiece(new Pawn(Color), cell);
            }

            cell.Y = (Color == SetColor.White) ? 0 : 7;
            // Set rooks
            cell.X = 0;
            board.PlacePiece(new Rook(Color), cell);
            cell.X = 7;
            board.PlacePiece(new Rook(Color), cell);
            // Set knights
            cell.X = 1;
            board.PlacePiece(new Knight(Color), cell);
            cell.X = 6;
            board.PlacePiece(new Knight(Color), cell);
            // Set bishops
            cell.X = 2;
            board.PlacePiece(new Bishop(Color),cell);
            cell.X = 5;
            board.PlacePiece(new Bishop(Color), cell);
            // Set queen
            cell.X = 3;
            board.PlacePiece(new Queen(Color), cell);
            // Set king
            cell.X = 4;
            TheKing = new King(Color);
            board.PlacePiece(TheKing, cell);
            TheKing.CurrentCell = cell;            
        }

        public void Move(Cell origCell, Cell destCell)
        {            
            // transform user's coordinates to board's 
            origCell--;
            destCell--;

            Piece ourPiece = board.CheckPiece(origCell);

            if (ourPiece == null)
            {                
                throw new MovePieceException("This cell doesn't contain a piece");
            }
            // check if it's not our color - place it where it was
            if (ourPiece.Color != this.Color)
            {                
                throw new MovePieceException("You trying to move " + ourPiece.ToString() + "that isn't your piece");
            }
            
            // move our piece on the borad
            Piece removedPiece = board.MovePiece(ourPiece, origCell, destCell);
        }

        public bool IsKingUnderCheck()
        {
            if (TheKing != null)
            {
                return TheKing.IsUnderCheck(TheKing.CurrentCell);
            }
            return false;            
        }
    }
}
