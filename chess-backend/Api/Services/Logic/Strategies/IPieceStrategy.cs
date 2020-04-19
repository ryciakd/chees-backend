using Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Logic.Strategies
{
    public interface IPieceStrategy
    {
        Task<IEnumerable<BoardPostion>> GetAvailableMovesAsync(BoardPostion piecePostion);
    }
}
