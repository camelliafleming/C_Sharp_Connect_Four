# C_Sharp_Connect_Four

How to play game:

  -A dialog box will show when the game is started.
  
  -Select 'Yes' to play against the CPU
  
  -Select 'No' to play a 2-player game
  
  -Click in the column where you choose to move
  
  -The goal is to get 4 checkers in a row, either horizontally, vertically, or diagonally.
  
  -When playing against the CPU, click the mouse to display the CPUs move. 
  
  -A label displays the column number where the last move was made to help keep track of the play.


Design Description: 
The game grid is created using PaintEventArgs and Graphics objects. A large rectangle is filled with Goldenrod and 7 rectangles overlay it to make the columns of the grid. Each of those columns is filled with 6 ellipses to hold the game pieces and create the rows of the grid. The ColumnNumber method uses the coordinates of the mouse click point and the rectangle columns to identify the column index. Each player move is detected by the mouse clicks to determine the column number. There is an EmptyRow method to determine the next empty slot in a column. That is where the game piece is entered. The GetCPUMove method uses a random integer to determine the column. The player must mouse click to see the CPUs move. 
The WinnerPlayer method checks to see if there are four game pieces in a row by determining if the row and/or column indices are equal in the appropriate pattern for a win. For a vertical win, the columns must be equal. For a horizontal win, the rows must be equal. For diagonal wins the row - column index must increase or decrease by one depending the direction of the diagonal.
