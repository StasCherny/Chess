using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Board
    {
        private static Board instance = new Board();
        private Piece[,] BoardOfPieces = new Piece[8,8];

        private Board() { Console.WriteLine("{0}", BoardOfPieces.Length); }

        public static Board Instance
        {            
            get
            {
                return instance;
            }            
        }

        public void Reset()
        {
            Array.Clear(BoardOfPieces,0,BoardOfPieces.Length);
        }

        public void PlacePiece(Piece piece, int destX, int destY)
        {
            BoardOfPieces[destX,destY] = piece;
        }
    }
}
