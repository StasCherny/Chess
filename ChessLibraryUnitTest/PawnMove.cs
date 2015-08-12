using ChessLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class PawnMove
    {
        [TestMethod()]
        public void MoveValidationTest_Success()
        {            
            Pawn white_pawn = new Pawn(SetColor.White);
            Cell origCell = new Cell(1,1);            

            Cell destCell = new Cell(1,3);
            white_pawn.MoveValidation(origCell, destCell);

            destCell.Y = 2;
            white_pawn.MoveValidation(origCell, destCell);

            Pawn black_pawn = new Pawn(SetColor.Black);
            origCell.Y = 7;
            destCell.Y = 5;
            black_pawn.MoveValidation(origCell, destCell);

            destCell.Y = 6;
            black_pawn.MoveValidation(origCell, destCell);
        }
    }
}