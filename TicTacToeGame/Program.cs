using BoardLogic;
using System;

namespace TicTacToeGame
{
    class Program
    {

        //1 is player1, and  plays with "X"
        //2 is player2, and  plays with "O"
       static Board game = new Board();   // tictactoe board is a part of the main program 
                                          //i created a reference to make Board be vesible to TicTacToeGame project
        static void Main(string[] args)
        {
            //undefinied values for the first turn, we cant set it as 0 beacyse grid contains o button0
            int userTurn = -1; 
            int computerTurn = -1;
            Random random = new Random();// create random object that will choose random numbers
            //keep playing utnil someone wins the game
            while (game.checkWinner() == 0)
            {
                //get valid input from user
                //not allow to enter already occupied square by user
                while (userTurn == -1 || game.Grid[userTurn] != 0) // this loop will continue till the time 
                                                                   //that the choosed grid is not equal to 0  or userTurn equals -1
                {
                    Console.WriteLine("enter number from 0 to 8:");
                    userTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You entered :" + userTurn);
                }
                game.Grid[userTurn] = 1;   //fills the choosed userturn with X

                //either userTurn was the last availbale one , the board considered to be full
                if (game.isBoardFull())    //if the board is full the process will stop
                {
                    break;
                }
                //get a random number from computer
                //not allow to enter already occupied square by computer
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)// this loop will continue till the time
                                                                          //that the choosed grid is not equal to 0  or computerturn equals -1
                {
                    computerTurn = random.Next(8); // we assign computer turn to the random number from 0 to 8
                    Console.WriteLine("Computer choosed " + computerTurn);
                }
                game.Grid[computerTurn] = 2;  //fill the random choosed computerturn with O
                //either computerTurn was the last availbale one , the board considered to be full
                if (game.isBoardFull())       //if the board is full the process will stop
                {
                    break;
                }
                printBoard();  // and print new board based on the inputs from user and randomchoise of computer
            }
            //when program found a win in  a game
            Console.WriteLine("The game is finished ");
            //while is done
            Console.WriteLine("Player " + game.checkWinner() + " won the game!");
            Console.ReadLine(); //won't close the  game after program is finished
          
        }

        private static void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                //print the board
                //print x or o for each square
                //0 ->unoccupied    1 -> X    2 -> O
                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("O");
                }
                //print a new row
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }

        
        }
    }



