namespace TicTacWowKiller.Models;

public class TicTacToeGame
{
    public char[,] Board { get; private set; } // 3x3 board
    public char CurrentPlayer { get; private set; } // 'X' or 'O'
    public bool isGameOver { get; private set; } // If game has ended

    public TicTacToeGame()
    {
        Board = new char[3, 3]; // Creates the game
        CurrentPlayer = 'X'; // 'X' always starts first
        isGameOver = false;
        InitializeBoard();
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
    
    
}