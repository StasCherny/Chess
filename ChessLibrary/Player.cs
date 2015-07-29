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
        // Constructor
        public Player(string name, SetColor setColor)
        {
            Name = name;
            Color = setColor;
            SetPieces();
        }

        public string Name { get; private set; }
        public SetColor Color { get; private set; }


        private void SetPieces()
        {
            int destY;

            // Set pawns
            destY = (Color == SetColor.White) ?  1 :  6;	        
            
            for (int i = 0; i < 8; i++)
            {
                board.PlacePiece(new Pawn(Color), i, destY);
            }

            destY = (Color == SetColor.White) ? 0 : 7;
            // Set rooks
            board.PlacePiece(new Rook(Color), 0, destY);
            board.PlacePiece(new Rook(Color), 7, destY);
            // Set knights
            board.PlacePiece(new Knight(Color), 1, destY);
            board.PlacePiece(new Knight(Color), 6, destY);
            // Set bishops
            board.PlacePiece(new Bishop(Color), 2, destY);
            board.PlacePiece(new Bishop(Color), 5, destY);
            // Set queen
            board.PlacePiece(new Queen(Color), 3, destY);
            // Set king
            board.PlacePiece(new King(Color), 4, destY);
        }

        public void Move(int origX, int origY, int destX, int destY)
        {
            Console.WriteLine("{0} {1} {2} {3}", origX, origY, destX, destY);
            // transform user's coordinates to board's 
            origX--;
            origY--;
            destX--;
            destY--;

            Piece ourPiece = board.GetPiece(origX, origY);
            // check if it's not our color - place it where it was
            if (ourPiece.Color != this.Color)
            {
                Console.WriteLine("You trying to move {0} that isn't your piece", ourPiece.ToString());
                board.PlacePiece(ourPiece, origX, origY);
                throw new Exception();
            }
            // place our pice on the borad
            Piece removedPiece;
            board.ReplacePiece(ourPiece, destX, destY, out removedPiece);
        }
        

    }
}
