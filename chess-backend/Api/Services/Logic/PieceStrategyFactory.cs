using Api.Common;
using Api.Services.Logic.Strategies;

namespace Api.Services.Logic
{
    public class PieceStrategyFactory : IPieceStrategyFactory
    {
        public IPieceStrategy Create(PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Rook:
                    return new RookStrategy();
                case PieceType.Queen:
                    return new QueenStrategy();
                default:
                    return null;
            }
        }
    }
}
