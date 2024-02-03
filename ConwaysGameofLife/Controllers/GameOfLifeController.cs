using ConwaysGameofLife.BusinessRules.Rules.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConwaysGameofLife.Application.Controllers
{
    [ApiController]
    [Route("api/gameoflife/[action]")]
    public class GameOfLifeController : Controller
    {
        private readonly IGameOfLifeBL _gameOfLifeBL;
        private readonly ILogger<GameOfLifeController> _logger;
        
        public GameOfLifeController(
            IGameOfLifeBL gameOfLifeBL,
            ILogger<GameOfLifeController> logger
            )
        {
            _logger = logger;
            _gameOfLifeBL = gameOfLifeBL;
        }

        [ActionName("board/randomize")]
        [HttpGet("{rows}/{cols}")]
        public string NewBoard(int rows, int cols)
        {
            try
            {
                string board = _gameOfLifeBL.GetNewBoard(rows, cols);
                return board;

            }
            catch (Exception)
            {
                throw;
            }
        }   

        [ActionName("board")]
        [HttpPost]
        public int UploadBoard([FromBody] string board)
        {
            try
            {
                int boardId = _gameOfLifeBL.UploadBoard(board);
                return boardId;
            }
            catch(Exception)
            {
                throw;
            }           
        }

        [ActionName("board")]        
        [HttpGet("{boardId}")]
        public string GetBoardById(int boardId)
        {
            try
            {
                string board = _gameOfLifeBL.GetBoardById(boardId);
                return board;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ActionName("board/next-generation")]
        [HttpPut("{boardId}")]
        public string GetNextGenerationByBoardId(int boardId)
        {
            try
            {
                string board = _gameOfLifeBL.GetNextGeneration(boardId);
                return board;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ActionName("board/states-away")]
        [HttpGet("{boardId}")]
        public int GetsNumberOfStatesAwayForBoardById(int boardId)
        {
            try
            {
                int result = _gameOfLifeBL.GetsNumberOfStatesAwayForBoardById(boardId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ActionName("board/final-state")]
        [HttpGet("{boardId}")]
        public string GetFinalStateBorBoard(int boardId)
        {
            try
            {
                string board = _gameOfLifeBL.GetBoardFinalState(boardId);
                return board;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
