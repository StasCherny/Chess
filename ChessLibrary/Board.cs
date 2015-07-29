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

        private Board() { }

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

        public void PlacePiece(Piece newPiece, int destX, int destY)
        {
            if (newPiece != null)
            {
                BoardOfPieces[destX, destY] = newPiece;
            }
        }

        public void ReplacePiece(Piece newPiece, int destX, int destY, out Piece oldPiece)
        {
            oldPiece = BoardOfPieces[destX, destY];            
            PlacePiece(newPiece, destX, destY);            
        }

        public Piece GetPiece(int destX, int destY)
        {
            Piece toReturn = BoardOfPieces[destX, destY];
            BoardOfPieces[destX, destY] = null;
            return toReturn;
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
                sb.AppendFormat("{0}   ", i + 1);
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
