using Api.Common;
using Api.Model;
using Api.Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class BoardService : IBoardService
    {
        private readonly IPieceStrategyFactory pieceStrategyFactory;

        public BoardService(IPieceStrategyFactory pieceStrategyFactory)
        {
            this.pieceStrategyFactory = pieceStrategyFactory;
        }

        public async Task<MoveCheckStatus> CheckMove(PieceType pieceType, BoardPostion currentPostion, BoardPostion boardPostion)
        {
             var moves = await GetAvailableMoves(pieceType, currentPostion);

            if(moves == null)
            {
                return await Task.FromResult(MoveCheckStatus.Error);
            }

            return moves.Any(m => m.Equals(boardPostion))
                    ? MoveCheckStatus.Ok
                    : MoveCheckStatus.Invalid;
        }

        public async Task<IEnumerable<BoardPostion>> GetAvailableMoves(PieceType pieceType, BoardPostion piecePostion)
        {
            try
            {
                var pieceStrategy = pieceStrategyFactory.Create(pieceType);
                return await pieceStrategy.GetAvailableMovesAsync(piecePostion);
            }
            catch (Exception e)
            {
                //TODO: log expcetion
                return await Task.FromResult<IEnumerable<BoardPostion>>(null);
            }
        } 
    }
}
