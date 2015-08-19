using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChessLibrary.Tests.MoveValidator;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class QueenMove
    {
        [TestMethod()]
        public void QueenMoveValidationTest_Success()
        {
            Board.Instance.Reset();
            Queen white_queen = new Queen(SetColor.White);
            Queen black_queen = new Queen(SetColor.Black);

            // move along a diagonal
            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 7);
            Board.Instance.PlacePiece(white_queen, origCell);
            white_queen.MoveValidation(origCell, destCell);

            destCell.X = 1;
            destCell.Y = 7;
            white_queen.MoveValidation(origCell, destCell);

            destCell.X = 0;
            destCell.Y = 0;
            white_queen.MoveValidation(origCell, destCell);

            destCell.X = 7;
            destCell.Y = 1;
            white_queen.MoveValidation(origCell, destCell);

            // remove on a diagonal
            Board.Instance.PlacePiece(black_queen, destCell);
            white_queen.MoveValidation(origCell, destCell);

            // move along the X line            
            destCell.X = 7;
            destCell.Y = 4;            
            white_queen.MoveValidation(origCell, destCell);

            // move along the Y line
            destCell.X = 4;
            destCell.Y = 7;
            white_queen.MoveValidation(origCell, destCell);

            // remove 
            Board.Instance.PlacePiece(black_queen, destCell);
            white_queen.MoveValidation(origCell, destCell);

        }

        [TestMethod()]
        public void QueenMoveValidationTest_Fail()
        {
            Board.Instance.Reset();
            Queen white_queen = new Queen(SetColor.White);

            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 0);

            Board.Instance.PlacePiece(white_queen, origCell);

            MoveValidatorDelegate queen_moveValid = delegate () { white_queen.MoveValidation(origCell, destCell); };

            // can move along a diagonal or a line only 
            AssertDoesNotThrowException(queen_moveValid);

            // can't remove a piece of the same color
            Queen white_queen2 = new Queen(SetColor.White);
            destCell.Y = 1;
            Board.Instance.PlacePiece(white_queen2, destCell);
            AssertDoesNotThrowException(queen_moveValid);

            // can't move while an other piece on the way
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_queen, origCell);
            destCell.X = 6;
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_queen2, destCell);
            destCell.X = 7;
            destCell.Y = 1;
            AssertDoesNotThrowException(queen_moveValid);
            destCell.X = 1;
            destCell.Y = 4;
            Board.Instance.PlacePiece(white_queen2, destCell);
            destCell.X = 0;
            destCell.Y = 4;
            AssertDoesNotThrowException(queen_moveValid);
        }
    }
}
