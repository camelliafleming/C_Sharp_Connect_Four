using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Connect_Four
{
    public partial class Connect_Four : Form
    {
        private Rectangle[] gridColumns;
        private int XSIZE = 7;
        private int YSIZE = 6; 
        private int[,] grid;
        private int turn;
        private int numPlayers;
        private int columnIndex;
        private string player;

        public Connect_Four()
        {
            InitializeComponent();
            this.gridColumns = new Rectangle[XSIZE];     //defines columns within game grid
            this.grid = new int[YSIZE, XSIZE];            //defines 6 x 7 array used to determine location of player moves



            if (MessageBox.Show("Click 'Yes' for Single Player \n Click 'No' for Two Players", "Answer me", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                numPlayers = 2;
                lblNumPlayers.Text = "2-Player Game";
                lblNumPlayers.Visible = true;
                this.turn = 3;
            }
            else
            {
                numPlayers = 1;
                lblNumPlayers.Text = "1-Player Game";
                lblNumPlayers.Visible = true;
                this.turn = 2;
            }
            

        }

        //paint method to draw game grid
        private void Connect_Four_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.FillRectangle(Brushes.Goldenrod, 24, 24, 340, 300);
            for(int i=0; i<YSIZE; i++)
            {
                for(int j = 0; j<XSIZE; j++)
                {
                    if(i == 0)
                    {
                        this.gridColumns[j] = new Rectangle(32 + 48 * j, 24, 32, 300);
                    }
                    e.Graphics.FillEllipse(Brushes.White, 32 + 48 * j, 32 + 48 * i, 32, 32);
                }
            }
        }

        private void Connect_Four_MouseClick(object sender, MouseEventArgs e)
        {
            if (numPlayers == 2)
            {
                columnIndex = this.ColumnNumber(e.Location);                                   //column selected by player
                if (columnIndex != -1)
                {
                    int rowIndex = this.EmptyRow(columnIndex);                                      //row selected by player
                    if (rowIndex != -1)
                    {
                        this.lblLastTurn.Text = "Last move: " + (columnIndex + 1);                  //Display column number of last move

                        this.grid[rowIndex, columnIndex] = this.turn;
                        if (this.turn == 3)
                        {
                            Graphics g = this.CreateGraphics();
                            g.FillEllipse(Brushes.DarkRed, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);          //inserts red checker for player 1 to identified location
                        }
                        else if (this.turn == 4)
                        {
                            Graphics g = this.CreateGraphics();
                            g.FillEllipse(Brushes.Blue, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);                     //inserts blue checker for player 2 to identified location
                        }

                        int winner = this.WinnerPlayer(this.turn);                                  //checks for winner
                        if (winner != -1)
                        {
                            if (winner == 3)
                            {
                                MessageBox.Show("Congratulations! Red Player ");             //displays message if there is a winner and restarts game
                            }
                            else if (winner == 4)
                            {
                                MessageBox.Show("Congratulations! Blue Player ");             //displays message if there is a winner and restarts game
                            }

                            Application.Restart();
                        }

                        if (this.turn == 3)                                                         //if no winner, changes turn for next player
                            this.turn = 4;
                        else
                            this.turn = 3;
                    }

                }
            }
            else if (numPlayers == 1)
            {

                if (this.turn == 1)
                     columnIndex = this.ColumnNumber(e.Location);
                else if (this.turn == 2)
                     columnIndex = GetCPUMove();

                if (columnIndex != -1)
                {
                    int rowIndex = this.EmptyRow(columnIndex);                                      //row selected by player
                    if (rowIndex != -1)
                    {
                        this.lblLastTurn.Text = "Last move: " + (columnIndex + 1);                  //Display column number of last move
                        this.grid[rowIndex, columnIndex] = this.turn;
                        if (this.turn == 1)
                        {
                            Graphics g = this.CreateGraphics();
                            g.FillEllipse(Brushes.DarkRed, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);           //inserts red checker for player 1 to identified location
                        }
                        else if (this.turn == 2)
                        {
                            int milliseconds = 1000;
                            Thread.Sleep(milliseconds);
                            Graphics g = this.CreateGraphics();
                            g.FillEllipse(Brushes.Blue, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);              //inserts blue checker for CPU to identified location
                        }

                        int winner = this.WinnerPlayer(this.turn);                                  //checks for winner
                        if (winner != -1)
                        {
                            if (winner == 1)
                            {
                                MessageBox.Show("Congratulations! Red Player ");             //displays message if there is a winner and restarts game
                            }
                            else if (winner == 2)
                            {
                                MessageBox.Show("Congratulations! Blue Player ");             //displays message if there is a winner and restarts game
                            }
                            Application.Restart();
                        }

                        if (this.turn == 1)                                                         //if no winner, changes turn for next player
                            this.turn = 2;
                        else
                            this.turn = 1;

                    }
                }

            }  
        }

        private int GetCPUMove()
        {
            Random rand = new Random();
            int x = rand.Next(0, 7);                                                            //Random int selected by CPU
            int y = x;


            return x;
        }

        //method to determine winning cases
        private int WinnerPlayer(int playerToCheck)
        {
            //vertical win check (\)
            for (int row=0; row < this.grid.GetLength(0)-3; row++)
            {
                for (int col = 0; col < this.grid.GetLength(1); col++)
                {
                    if (this.AllNumbersEqual(playerToCheck, this.grid[row, col], this.grid[row + 1, col], this.grid[row + 2, col], this.grid[row + 3, col]))
                        return playerToCheck;
                }
            }

            //horizontal win check (-)
            for(int row = 0; row < this.grid.GetLength(0); row++)
            {
                for(int col = 0; col < this.grid.GetLength(1) - 3; col++)
                {
                    if (this.AllNumbersEqual(playerToCheck, this.grid[row, col], this.grid[row, col+1], this.grid[row, col+2], this.grid[row, col+3]))
                        return playerToCheck;
                }
            }

            //downward diagonal (\) win check
            for (int row = 0; row < this.grid.GetLength(0) - 3; row++)
            {
                for (int col = 0; col < this.grid.GetLength(1) - 3; col++)
                {
                    if (this.AllNumbersEqual(playerToCheck, this.grid[row, col], this.grid[row + 1, col + 1], this.grid[row + 2, col  + 2], this.grid[row + 3, col + 3]))
                        return playerToCheck;
                }
            }

            //forward diagonal (/) win check
            for (int row = 0; row < this.grid.GetLength(0) - 3; row++)
            {
                for (int col = 3; col < this.grid.GetLength(1); col++)
                {
                    if (this.AllNumbersEqual(playerToCheck, this.grid[row, col], this.grid[row + 1, col - 1], this.grid[row + 2, col - 2], this.grid[row + 3, col - 3]))
                        return playerToCheck;
                }
            }

            return -1;
        }

        //method to determine if row index or column index is the same
        private bool AllNumbersEqual(int toCheck, params int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num!= toCheck)
                    return false;
            }
            return true;
        }

        //method to get (x,y) coordinates of mouse
        private int ColumnNumber(Point mouse)
        {
            for(int i = 0; i < this.gridColumns.Length; i++)
            {
                if ((mouse.X >= this.gridColumns[i].X) && (mouse.Y >= this.gridColumns[i].Y))
                {
                    if((mouse.X <= this.gridColumns[i].X + this.gridColumns[i].Width) && (mouse.Y <= this.gridColumns[i].Y + this.gridColumns[i].Height))
                    {
                        return i; //returns the index of the column player clicked
                    }
                }
            }
            return -1;
        }

        //method to determine the next empty row
        private int EmptyRow(int XSIZE)
        {
            for(int i = 5; i >= 0; i--)
            {
                if (this.grid[i, XSIZE] == 0)
                    return i;   //returns the index of the next empty row
            }
            return -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
