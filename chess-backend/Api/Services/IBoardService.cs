using Api.Common;
using Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardPostion>> GetAvailableMoves(PieceType pieceType, BoardPostion piecePostion);
          
        Task<MoveCheckStatus> CheckMove(PieceType pieceType, BoardPostion currentPostion, BoardPostion boardPostion);
    }
}
