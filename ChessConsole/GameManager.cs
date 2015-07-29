using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChessLibrary;


namespace ChessConsole
{
    public class GameManager
    {
        private Player[] GamePlayers = new Player[2];
        private int CurrentPlayer;
        private Dictionary<char,int> LetterToNumber = new Dictionary<char,int>();

        public GameManager()
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            for (int i = 0; i < letters.Length; i++)
            {
                LetterToNumber.Add(letters[i], i + 1);
            }
        }

        static public void Start()
        {
            Console.WriteLine("====== Welocome to Chess ======");
            Console.WriteLine("====== Let's start ======");

            GameManager gm = new GameManager();

            gm.CreatePlayers();            

            try
            {
                while (true)
                {                   
                    gm.Move();                   
                }           
            }
            catch (Exception)
            {
                Console.Write("Good bye!!!");
            }
             
            Console.ReadLine();
        }

        private void CreatePlayers()
        {
            // create first player
            Console.Write("Enter a name of the first player > ");
            string name = Console.ReadLine();

            while (true)
            {                
                Console.Write("{0}, what is a color of your set? (w/b) ", name);
                string color = Console.ReadLine();
                color.ToLower();
                if (color == "w")
                {
                    GamePlayers[0] = new Player(name, SetColor.White);
                    CurrentPlayer = 0;
                    break;
                }
                else if (color == "b")
                {
                    GamePlayers[0] = new Player(name, SetColor.Black);
                    CurrentPlayer = 1;
                    break;
                }
                else
                {
                    Console.WriteLine("{0}, wrong input. Please type 'w' or 'b' >", name);
                }                
            }
            Console.WriteLine("{0}, a color of your set is {1}", GamePlayers[0].Name, GamePlayers[0].Color.ToString());

            // create second player
            Console.Write("Enter a name of the second player > ");
            name = Console.ReadLine();                            

            if (GamePlayers[0].Color == SetColor.White)
            {
                GamePlayers[1] = new Player(name, SetColor.Black);                                 
            }
            else // first is black
            {
                GamePlayers[1] = new Player(name, SetColor.White);           
            }
            Console.WriteLine("{0}, a color of your set is {1}", GamePlayers[1].Name, GamePlayers[1].Color.ToString());
            
        }

        private void Move()
        {
            Console.WriteLine("Player {0}", GamePlayers[CurrentPlayer].Color.ToString());
            Console.Write("{0}, Make a move > ", GamePlayers[CurrentPlayer].Name);
            string move = Console.ReadLine();
            move.ToLower();
            if (move == "q")
            {         
                throw new Exception();
            }
            else if(move == "print")
            {
                Console.Write(Board.Instance.ToString());
                return;
            }
            
            // Validate moves input
            //string[] sep = {" ","-" };
            //var moves = move.Split(sep,sep.Length,StringSplitOptions.RemoveEmptyEntries);            
            var moves = move.Split(' ');            
            if (moves.Length != 2 || moves[0].Length != 2 || moves[1].Length != 2)             
            {
                Console.WriteLine("Worng syntax! (ex. e2 e4)");
                return;
            }

            if (!Regex.IsMatch(moves[0][0].ToString(),"[a-h]") || !Regex.IsMatch(moves[1][0].ToString(),"[a-h]"))
            {
                Console.WriteLine("Worng syntax! (range is from 'a' to 'h')");
                return;
            }

            if (!Regex.IsMatch(moves[0][1].ToString(), "[1-8]") || !Regex.IsMatch(moves[1][1].ToString(), "[1-8]"))
            {
                Console.WriteLine("Worng syntax! (range is from '1' to '8')");
                return;
            }
           
            
            // Move player
            try
            {
                GamePlayers[CurrentPlayer].Move(LetterToNumber[moves[0][0]], Convert.ToInt32(moves[0][1].ToString()),
                                                LetterToNumber[moves[1][0]], Convert.ToInt32(moves[1][1].ToString()));
            }
            catch(Exception)
            {
                return;
            }

            CurrentPlayer = (CurrentPlayer + 1) % 2;
            
        }
    }
}
