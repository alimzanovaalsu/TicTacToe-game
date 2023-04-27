using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//another project "BoardLogic" 
//library that stores game logic
namespace BoardLogic
{ //moving game logic from Program to Board
    public class Board
    {
        // the only data of the board , is an array of integers
        public int[]  Grid
        {
            get;set;
        }

        public Board() //creates a board contructor 
        {
            Grid = new int[9];
            //initialize the board
            //set all boxes empty
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0;
            }
        }

        public bool isBoardFull()
        {    //assume that the board is full
            bool isFull = true;
            //consider the board is full .
            //if an exception is found, change the bool
            for(int i = 0; i < Grid.Length; i++) 
            {   // cheack every elemnt of the board if it is empty
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }
            return isFull;
        }
        public  int checkWinner()
        {
            //return 0 if nobody won
            //return 1 if player1 won
            //return 2 if player2 won


            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                return Grid[0];
            }
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                return Grid[3];
            }
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                return Grid[6];
            }
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                return Grid[0];
            }
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                return Grid[1];
            }
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                return Grid[2];
            }
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                return Grid[0];
            }
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                return Grid[2];
            }

            return 0;

        }


    }
}
