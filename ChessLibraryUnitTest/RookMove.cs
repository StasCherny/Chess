using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChessLibrary.Tests.MoveValidator;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class RookMove
    {
        [TestMethod()]
        public void RookMoveValidationTest_Success()
        {
            Board.Instance.Reset();
            Rook white_rook = new Rook(SetColor.White);
            Rook black_rook = new Rook(SetColor.Black);

            // move along the X line
            Cell origCell = new Cell(0, 0);
            Cell destCell = new Cell(7, 0);
            Board.Instance.PlacePiece(white_rook, origCell);
            white_rook.MoveValidation(origCell, destCell);

            // move along the Y line
            destCell.X = 0;
            destCell.Y = 7;
            white_rook.MoveValidation(origCell, destCell);

            // remove 
            Board.Instance.PlacePiece(black_rook, destCell);
            white_rook.MoveValidation(origCell, destCell);
        }

        [TestMethod()]
        public void RookMoveValidationTest_Fail()
        {
            Board.Instance.Reset();
            Rook white_rook = new Rook(SetColor.White);

            Cell origCell = new Cell(0, 0);
            Cell destCell = new Cell(7, 1);

            Board.Instance.PlacePiece(white_rook, origCell);

            MoveValidatorDelegate rook_moveValid = delegate () { white_rook.MoveValidation(origCell, destCell); };

            // can move along a line only 
            AssertDoesNotThrowException(rook_moveValid);

            // can't remove a piece of the same color
            Rook white_rook2 = new Rook(SetColor.White);
            destCell.Y = 0;
            Board.Instance.PlacePiece(white_rook2, destCell);
            AssertDoesNotThrowException(rook_moveValid);

            // can't move while an other piece on the way
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_rook, origCell);
            destCell.X = 3;
            Board.Instance.PlacePiece(white_rook2, destCell);
            destCell.X = 7;
            AssertDoesNotThrowException(rook_moveValid);
        }
    }
}
