using Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Logic.Strategies
{
    public abstract class PieceStrategyBase : IPieceStrategy
    {
        protected const int BoardSize = 8;

        public async Task<IEnumerable<BoardPostion>> GetAvailableMovesAsync(BoardPostion piecePostion)
        {
            return await Task.Run(() => GetAvailableMoves(piecePostion));
        }

        protected abstract IEnumerable<BoardPostion> GetAvailableMoves(BoardPostion piecePostion);
    }
}
