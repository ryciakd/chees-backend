using Api.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Logic.Strategies
{
    public class QueenStrategy : IPieceStrategy
    {
        public async Task<IEnumerable<BoardPostion>> GetAvailableMovesAsync(BoardPostion piecePostion)
        {
            throw new NotImplementedException();
        }
    }
}
