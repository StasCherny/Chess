﻿using ChessLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class PawnMove
    {       
        [TestMethod()]
        public void PawnMoveValidationTest_Success()
        {            
            Pawn white_pawn = new Pawn(SetColor.White);
            Cell origCell = new Cell(1,1);            

            Cell destCell = new Cell(1,3);
            // first move 2 cells
            white_pawn.MoveValidation(origCell, destCell);

            destCell.Y = 2;
            // move one cell
            white_pawn.MoveValidation(origCell, destCell);

            Pawn black_pawn = new Pawn(SetColor.Black);
            origCell.Y = 7;
            destCell.Y = 5;
            // first move 2 cells
            black_pawn.MoveValidation(origCell, destCell);
            // move one cell
            destCell.Y = 6;
            black_pawn.MoveValidation(origCell, destCell);

            // remove
            Board board = Board.Instance;
            origCell.X = 4;
            origCell.Y = 1;
            board.PlacePiece(white_pawn, origCell);
            destCell.X = 3;
            destCell.Y = 2;
            board.PlacePiece(black_pawn, destCell);

            white_pawn.MoveValidation(origCell, destCell);

            black_pawn.MoveValidation(destCell, origCell);
        }

        [TestMethod()]     
        public void PawnMoveValidationTest_Fail()
        {
            Pawn white_pawn = new Pawn(SetColor.White);
            Pawn white_pawn2 = new Pawn(SetColor.White);
            Cell origCell = new Cell(1, 1);
            Cell destCell = new Cell(1, 4);

            MoveValidator.MoveValidatorDelegate white_moveValid = delegate () { white_pawn.MoveValidation(origCell, destCell); };


            // move more than 2 cells            
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // first move 2 cells with some piece on the way
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_pawn2, destCell);
            destCell.Y = 3;
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // first move 2 cells
            Board.Instance.Reset();   // remove previously placed piece
            MoveValidator.AssertThrowException(white_moveValid);  // allowed move, shouldn't throw exception
            // second move 2 cells         
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // move backward
            destCell.Y = 0;
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // move along diagonal to empty cell
            destCell.X = 2;
            destCell.Y = 2;
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            destCell.X = 0;
            destCell.Y = 2;
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // try to move along the column when cell isn't empty
            destCell.X = 1;
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_pawn2, destCell);
            MoveValidator.AssertDoesNotThrowException(white_moveValid);
            // try to remove a piece of the same color
            destCell.X = 2;
            destCell.Y = 2;
            Board.Instance.PlacePiece(white_pawn2, destCell);
            MoveValidator.AssertDoesNotThrowException(white_moveValid);         
        }
    }
}