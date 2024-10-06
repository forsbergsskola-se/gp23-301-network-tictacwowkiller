using TicTacWowKiller.Models;
using Microsoft.AspNetCore.Mvc;

namespace TicTacWowKiller.Controllers;

public class TicTacController
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
            return Ok(game.Board); // Returns 3X3 board as a JSON response
        }

        //Api to make move on board
        [HttpPost("move")]
        public IActionResult MakeMove([FromQuery] int row, [FromQuery] int col)
        {
            // Checks if the row and column are valid
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return BadRequest("Invalid Move! Row and column must be between 0 and 2.");
            }

            //Try to make move on the board
            bool success = game.MakeMove(row, col);
            if (!success)
            {
                return BadRequest("Invalid Move or game is over");
            }

            //Return the updated board and game status
            return Ok(new { Board = game.Board, CurrentPlayer = game.CurrentPlayer, IsGameOver = game.isGameOver });
        }

        // API to restart the game (for rematch)
        [HttpPost("restart")]
        public IActionResult RestartGame()
        {
            game = new TicTacToeGame(); // Creates a new game instance
            return Ok("Game Restarted.");
        }
    }
}