using Api.Model;
using System.Collections.Generic;

namespace Api.Services.Logic.Strategies
{
    public class RookStrategy : PieceStrategyBase
    {
        protected override IEnumerable<BoardPostion> GetAvailableMoves(BoardPostion piecePostion)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i != piecePostion.Row)
                {
                    yield return new BoardPostion(i, piecePostion.Column);
                }
                if (i != piecePostion.Column)
                {
                    yield return new BoardPostion(piecePostion.Row, i);
                }
            }
        }
    }
}
