namespace TicTacWowKiller.Models;

public class TicTacToeGame
{
    public char[,] Board { get; private set; } //3x3 board
    public char CurrentPlayer { get; private set; } // 'X' or 'O'
    public bool isGameOver { get; private set; } //If game has ended
}