using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    [Serializable]
    public class MovePieceException : Exception
    {
        public MovePieceException() { }
        public MovePieceException(string message) : base(message) { }
        public MovePieceException(string message, Exception inner) : base(message, inner) { }
        protected MovePieceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
