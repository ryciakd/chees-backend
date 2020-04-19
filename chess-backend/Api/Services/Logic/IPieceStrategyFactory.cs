using Api.Common;
using Api.Services.Logic.Strategies;

namespace Api.Services.Logic
{
    public interface IPieceStrategyFactory
    {
        IPieceStrategy Create(PieceType pieceType);
    }
}
