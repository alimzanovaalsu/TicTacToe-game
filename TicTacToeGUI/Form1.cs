using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGUI
{
    public partial class Form1 : Form
    {

        Board game = new Board();  // we use board  logic
        Button[] buttons = new Button[9];
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();  //game has a new version of a board class
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            //add a click for every single button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += buttonClick;
                buttons[i].Tag = i; //Tag is a property of a button that
                                    // can handle any kind of a data (int,string and etc)
            }
        }

        private void buttonClick(object sender, EventArgs e) // object called sender = the value of which button is clicked ,
                                                             // eventArgs e an argument or issue when the button is clicked

        {
            Button clickedButton = (Button)sender; //we are casting sender to the Button
            int gameSquareNumber = (int)clickedButton.Tag; //make sure that tag is integer
            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full.Start new game!");
                disableAllButtons();
            }
            else if (game.checkWinner() == 1)
            {
                MessageBox.Show("User wins!");
                disableAllButtons();
            }
            else
            {
                //computeres turn
                computerStep();
            }
           

        }

        private void disableAllButtons()
        {
            foreach(var item in buttons) //we go through each item in list  buttons
            {
                item.Enabled = false;
            }
        }

        private void computerStep()
        {//computers turn to choose random number , and grid should reflet this number
         //not allow to enter already occupied square by computer
            int computerTurn = random.Next(9);
            while (computerTurn == -1 || game.Grid[computerTurn] != 0)
            {
                computerTurn = random.Next(8); // we assign computer turn to the random number from 0 to 8
                Console.WriteLine("Computer choosed " + computerTurn);
            }
            game.Grid[computerTurn] = 2;
            updateBoard();

            //check for win
            //check if the board is full

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full. Start new game!");
                disableAllButtons();
            }
            else if (game.checkWinner() == 2)
            {
                MessageBox.Show("Computer wins!");
                disableAllButtons();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {//assign x or o to the button
            for (int i = 0; i <game.Grid.Length; i++)
            {
                if(game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                }
                else if(game.Grid[i]==1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false; //does not allow enabling of the buttonafter it was already clicked
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false; //does not allow enabling of the buttonafter it was already clicked
                }
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();  //redefines all the properties
            enableAllButtons();
        }

        private void enableAllButtons()
        {
           foreach(var item in buttons)//checks every item in buttons 
            {
                item.Enabled = true;
            }

            updateBoard();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
