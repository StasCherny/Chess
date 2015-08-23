using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChessLibrary.Tests.MoveValidator;

namespace ChessLibrary.Tests
{
    [TestClass]
    public class KingMove
    {
        [TestMethod()]
        public void KingMoveValidationTest_Success()
        {
            Board.Instance.Reset();
            King white_king = new King(SetColor.White);
            Knight black_knight = new Knight(SetColor.Black);

            // move by one cell
            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(4, 5);
            Board.Instance.PlacePiece(white_king, origCell);
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 5;
            destCell.Y = 5;
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 5;
            destCell.Y = 4;
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 5;
            destCell.Y = 3;
            white_king.MoveValidation(origCell, destCell);
            
            destCell.X = 4;
            destCell.Y = 3;
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 3;
            destCell.Y = 3;
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 3;
            destCell.Y = 4;
            white_king.MoveValidation(origCell, destCell);

            destCell.X = 3;
            destCell.Y = 5;
            white_king.MoveValidation(origCell, destCell);

            // remove 
            Board.Instance.PlacePiece(black_knight, destCell);
            white_king.MoveValidation(origCell, destCell);

        }

        [TestMethod()]
        public void KingMoveValidationTest_Fail()
        {
            Board.Instance.Reset();
            King white_king = new King(SetColor.White);

            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 0);

            Board.Instance.PlacePiece(white_king, origCell);

            MoveValidatorDelegate king_moveValid = delegate () { white_king.MoveValidation(origCell, destCell); };

            // can move by one only 
            AssertDoesNotThrowException(king_moveValid);

            // can't remove a piece of the same color
            King white_king2 = new King(SetColor.White);
            destCell.X = 4;
            destCell.Y = 5;
            Board.Instance.PlacePiece(white_king2, destCell);
            AssertDoesNotThrowException(king_moveValid);            
        }

        [TestMethod()]
        public void IsUnderCheckTest()
        {
            Board.Instance.Reset();
            King white_king = new King(SetColor.White);

            Cell origCell = new Cell(4, 4);
            Cell destCell = new Cell(7, 7);

            Board.Instance.PlacePiece(white_king, origCell);

            // is checked by black bishop
            Bishop black_bishop = new Bishop(SetColor.Black);
            Board.Instance.PlacePiece(black_bishop, destCell);
            Assert.IsTrue(white_king.IsUnderCheck(origCell));

            // is checked by black pawn
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_king, origCell);
            destCell.X = 3;
            destCell.Y = 5;
            Pawn black_pawn = new Pawn(SetColor.Black);
            Board.Instance.PlacePiece(black_pawn, destCell);
            Assert.IsTrue(white_king.IsUnderCheck(origCell));

            // is checked by black king (diagonal)
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_king, origCell);
            destCell.X = 5;
            destCell.Y = 3;
            King black_king = new King(SetColor.Black);
            Board.Instance.PlacePiece(black_king, destCell);
            Assert.IsTrue(white_king.IsUnderCheck(origCell));            

            // is checked by black queen
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_king, origCell);
            destCell.X = 7;
            destCell.Y = 1;
            Queen black_queen = new Queen(SetColor.Black);
            Board.Instance.PlacePiece(black_queen, destCell);
            Assert.IsTrue(white_king.IsUnderCheck(origCell));

            // isn't checked by black queen
            Board.Instance.Reset();
            Board.Instance.PlacePiece(white_king, origCell);
            destCell.X = 7;
            destCell.Y = 1;            
            Board.Instance.PlacePiece(black_queen, destCell);
            Queen white_queen = new Queen(SetColor.White);
            destCell.X = 6;
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_queen, destCell);
            Assert.IsFalse(white_king.IsUnderCheck(origCell));

        }
    }
}
