using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    public static class MoveValidator
    {
        public delegate void MoveValidatorDelegate();

        public static void AssertThrowException(MoveValidatorDelegate func)
        {
            try
            {
                func();
            }
            catch (Exception)
            {

                throw new AssertFailedException();
            }
        }

        public static void AssertDoesNotThrowException(MoveValidatorDelegate func)
        {
            try
            {
                func();
                throw new AssertFailedException();  // shoudn't get there because must throw exception
            }
            catch (MovePieceException)
            {
                // it's Ok, do nothing
            }
            catch (Exception)
            {

                throw;  // just re-throw it
            }
        }
    }
}
