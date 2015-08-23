using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChessLibrary.Tests.MoveValidator;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class KnightMove
    {        
        [TestMethod()]
        public void KnightMoveValidationTest_Success()
        {
            Board.Instance.Reset();
            Knight white_knight = new Knight(SetColor.White);
            Knight black_bishop = new Knight(SetColor.Black);

            // move
            Cell origCell = new Cell(2, 2);
            Cell destCell = new Cell(1, 0);
            Board.Instance.PlacePiece(white_knight, origCell);
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 0;
            destCell.Y = 1;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 0;
            destCell.Y = 3;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 1;
            destCell.Y = 4;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 3;
            destCell.Y = 4;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 4;
            destCell.Y = 3;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 4;
            destCell.Y = 1;
            white_knight.MoveValidation(origCell, destCell);

            destCell.X = 3;
            destCell.Y = 0;
            white_knight.MoveValidation(origCell, destCell);

            // remove 
            Board.Instance.PlacePiece(black_bishop, destCell);
            white_knight.MoveValidation(origCell, destCell);
        }

        [TestMethod()]
        public void KnightMoveValidationTest_Fail()
        {
            Board.Instance.Reset();
            Knight white_knight = new Knight(SetColor.White);

            Cell origCell = new Cell(2, 2);
            Cell destCell = new Cell(7, 0);

            Board.Instance.PlacePiece(white_knight, origCell);

            MoveValidatorDelegate knight_moveValid = delegate () { white_knight.MoveValidation(origCell, destCell); };

            // can move as knight only 
            AssertDoesNotThrowException(knight_moveValid);

            // can't remove a piece of the same color
            Knight white_knight2 = new Knight(SetColor.White);
            destCell.Y = 1;
            Board.Instance.PlacePiece(white_knight2, destCell);
            AssertDoesNotThrowException(knight_moveValid);           
        }        
    }
}
