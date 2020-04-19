using System;
using System.Threading.Tasks;
using Api.Common;
using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private const int InternalError = 500;
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAvailableMoves([FromQuery]PieceType pieceType, [FromQuery]int row, [FromQuery]int column)
        {
            var moves = await _boardService.GetAvailableMoves(pieceType, new BoardPostion(row, column));

            if(moves == null)
            {
                return StatusCode(InternalError);
            }

            return Ok(moves);
        }

        [HttpGet("{pieceId}")]
        public async Task<IActionResult> CheckMove(
            PieceType pieceType,
            [FromQuery]int currentRow,
            [FromQuery]int currentColumn,
            [FromQuery]int newRow,
            [FromQuery]int newColumn)
        {
            var moveStatus = await _boardService.CheckMove(
                pieceType,
                new BoardPostion(currentRow, currentColumn),
                new BoardPostion(newRow, newColumn));

            if(moveStatus == MoveCheckStatus.Error)
            {
                return StatusCode(InternalError);
            }

            return Ok(moveStatus);
        }

    }
}
