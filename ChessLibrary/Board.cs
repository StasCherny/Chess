using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary
{
    public class Board
    {
        private static Board instance = new Board();

        private Board() { }

        public static Board Instance
        {            
            get
            {
                return instance;
            }            
        }
    }
}
