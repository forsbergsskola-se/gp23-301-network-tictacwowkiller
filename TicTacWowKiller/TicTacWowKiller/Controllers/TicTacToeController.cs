using TicTacWowKiller.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TicTacWowKiller.Controllers
{
    [Route("api/[controller]")] //Set up for route like /api/tictactoe
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        //Static so all users interact with the same game
        private static TicTacToeGame game = new TicTacToeGame();

        //Api to get current board state
        [HttpGet("board")]
        public IActionResult GetBoard()
        {
            var boardList = new List<List<char>>();
            for (int i = 0; i < game.Board.GetLength(0); i++)
            {
                var row = new List<char>();
                for (int j = 0; j < game.Board.GetLength(1); j++)
                {
                    row.Add(game.Board[i, j]);
                }
                boardList.Add(row);
            }

            return Ok(boardList);
        }

        [HttpPost("move")]
        public IActionResult MakeMove([FromQuery] int row, [FromQuery] int col)
        {
            // Checks if the row and column are valid
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return BadRequest("Invalid Move! Row and column must be between 0 and 2.");
            }

            // Try to make move on the board
            bool success = game.MakeMove(row, col);
            if (!success)
            {
                return BadRequest("Invalid Move or game is over");
            }

            // Convert the 2D char array to a list of lists for JSON serialization
            var boardList = new List<List<char>>();
            for (int i = 0; i < game.Board.GetLength(0); i++)
            {
                var rowList = new List<char>();
                for (int j = 0; j < game.Board.GetLength(1); j++)
                {
                    rowList.Add(game.Board[i, j]);
                }
                boardList.Add(rowList);
            }

            // Return the updated board and game status using the converted board
            return Ok(new { Board = boardList, CurrentPlayer = game.CurrentPlayer, IsGameOver = game.isGameOver });
        }


        // API to restart the game (for rematch)
        [HttpPost("restart")]
        public IActionResult RestartGame()
        {
            game = new TicTacToeGame(); // Creates a new game instance
            return Ok("Game restarted.");
        }
    }
}