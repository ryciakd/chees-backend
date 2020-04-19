using Api.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Logic.Strategies
{
    public class RookStrategy : IPieceStrategy
    {
        public async Task<IEnumerable<BoardPostion>> GetAvailableMovesAsync(BoardPostion piecePostion)
        {
            return await Task.Run(() =>
            {
                return new[] { new BoardPostion(1, 1) };
            });
        }
    }
}
