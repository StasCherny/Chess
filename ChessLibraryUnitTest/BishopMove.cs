using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class BishopMove
    {
        [TestMethod()]
        public void BishopMoveValidationTest_Success()
        {
            Board.Instance.Reset();
            Bishop white_bishop = new Bishop(SetColor.White);
            Bishop black_bishop = new Bishop(SetColor.Black);

            // move along a diagonal
            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 7);
            Board.Instance.PlacePiece(white_bishop, origCell);
            white_bishop.MoveValidation(origCell, destCell);
            
            destCell.X = 1;
            destCell.Y = 7;
            white_bishop.MoveValidation(origCell, destCell);

            destCell.X = 0;
            destCell.Y = 0;
            white_bishop.MoveValidation(origCell, destCell);

            destCell.X = 7;
            destCell.Y = 1;
            white_bishop.MoveValidation(origCell, destCell);

            // remove 
            Board.Instance.PlacePiece(black_bishop, destCell);
            white_bishop.MoveValidation(origCell, destCell);
        }

        [TestMethod()]
        public void BishopMoveValidationTest_Fail()
        {
            Board.Instance.Reset();
            Bishop white_bishop = new Bishop(SetColor.White);

            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 0);

            Board.Instance.PlacePiece(white_bishop, origCell);

            MoveValidator.MoveValidatorDelegate bishop_moveValid = delegate () { white_bishop.MoveValidation(origCell, destCell); };

            // can move along a diagonal only 
            MoveValidator.AssertDoesNotThrowException(bishop_moveValid);

            // can't remove a piece of the same color
            Bishop white_bishop2 = new Bishop(SetColor.White);
            destCell.Y = 1;
            Board.Instance.PlacePiece(white_bishop2, destCell);
            MoveValidator.AssertDoesNotThrowException(bishop_moveValid);

            // can't move while an other piece on the way
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_bishop, origCell);
            destCell.X = 6;
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_bishop2, destCell);
            destCell.X = 7;
            destCell.Y = 1;
            MoveValidator.AssertDoesNotThrowException(bishop_moveValid);
        }
    }
}
