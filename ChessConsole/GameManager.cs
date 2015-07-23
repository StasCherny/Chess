﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary;


namespace ChessConsole
{
    public class GameManager
    {
        private Player[] GamePlayers = new Player[2];
        private int CurrentPlayer;

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
            Console.Write("{0}, Make a move > ", GamePlayers[CurrentPlayer].Name);
            string move = Console.ReadLine();
            if (move == "q")
            {         
                throw new Exception();
            }
            
            // Validate move
            //TODO
            // Move player
            //GamePlayers[CurrentPlayer].Move();
            Console.WriteLine("Player {0}", GamePlayers[CurrentPlayer].Color.ToString());
            CurrentPlayer = (CurrentPlayer + 1) % 2;
            
        }
    }
}
