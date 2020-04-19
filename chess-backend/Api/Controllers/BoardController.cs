using System;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet("moves")]
        public async Task<IActionResult> GetAvailableMoves(
            [FromQuery][Required]PieceType pieceType,
            [FromQuery][Required]int row,
            [FromQuery][Required]int column)
        {
            var moves = await _boardService.GetAvailableMoves(pieceType, new BoardPostion(row, column));

            if(moves == null)
            {
                return StatusCode(InternalError);
            }

            return Ok(moves);
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckMove(
            [FromQuery][Required]PieceType pieceType,
            [FromQuery][Required]int currentRow,
            [FromQuery][Required]int currentColumn,
            [FromQuery][Required]int newRow,
            [FromQuery][Required]int newColumn)
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
