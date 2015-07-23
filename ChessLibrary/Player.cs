using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Player
    {        

        // Constructor
        public Player(string name, SetColor setColor)
        {
            Name = name;
            Color = setColor;
        }

        public string Name { get; private set; }
        public SetColor Color { get; private set; }

        
    }
}
