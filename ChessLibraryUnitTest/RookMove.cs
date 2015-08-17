using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class RookMove
    {
        [TestMethod()]
        public void RookMoveValidationTest_Success()
        {
            Rook rook = new Rook(SetColor.White);

            // move along the X line
            Cell origCell = new Cell(0, 0);
            Cell destCell = new Cell(7, 0);
            rook.MoveValidation(origCell, destCell);

            // move along the Y line
            destCell.X = 0;
            destCell.Y = 7;
            rook.MoveValidation(origCell, destCell);
        }

        [TestMethod()]
        public void RookMoveValidationTest_Fail()
        {
            
            //MoveValidator.AssertDoesNotThrowException(white_moveValid);            
            //MoveValidator.AssertThrowException(white_moveValid);  // allowed move, shouldn't throw exception
            Rook rook = new Rook(SetColor.White);

            Cell origCell = new Cell(0, 0);
            Cell destCell = new Cell(7, 1);
            MoveValidator.MoveValidatorDelegate rook_moveValid = delegate () { rook.MoveValidation(origCell, destCell); };
            // can move along a line only 
            MoveValidator.AssertDoesNotThrowException(rook_moveValid);            
        }
    }
}
