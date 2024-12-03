namespace TicTacWowKiller.Models;

public class TicTacToeGame
{
    public char[,] Board { get; private set; } // 3x3 board
    public char CurrentPlayer { get; private set; } // 'X' or 'O'
    public bool isGameOver { get; private set; } // If game has ended

    public TicTacToeGame()
    {
        Board = new char[3, 3]; // Creates the game
        InitializeBoard();
        CurrentPlayer = 'X'; // 'X' always starts first
        isGameOver = false;
        
    }

    //Initialize the board with '-' to represent empty cells
    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = '-';
            }
        }
    }

    //Handles moves
    public bool MakeMove(int row, int col)
    {
        //Check if the move is valid (an empty slot)
        if (Board[row, col] != '-' || isGameOver) return false;
        
        //Updates the board with current players move
        Board[row, col] = CurrentPlayer;

        //Checks if Current player has won the game 
        if (CheckWin())
        {
            isGameOver = true;
        }
        else
        {
            //If no one wins, switch current player
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
        }

        return true; //if the move is successful 
    }

    private bool CheckWin()
    {
        //Checks the rows, columns and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            if (Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer)
                return true;
            if (Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer)
                return true;
        }
        
        //Check diagonal (top-left to bottom-right)
        if (Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer) return true;
        
        //Check diagonal (top-right to bottom-left
        if (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer) return true;

        return false;
    }
}