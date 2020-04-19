using Api.Model;
using System.Collections.Generic;

namespace Api.Services.Logic.Strategies
{
    public class QueenStrategy : PieceStrategyBase
    {
        protected override IEnumerable<BoardPostion> GetAvailableMoves(BoardPostion piecePostion)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (i != piecePostion.Row)
                {
                    yield return new BoardPostion(i, piecePostion.Column);
                }
                if (i != piecePostion.Column)
                {
                    yield return new BoardPostion(piecePostion.Row, i);
                }
                if (i > 0)
                {
                    if (piecePostion.Row - i >= 0 && piecePostion.Column - i >= 0)
                    {
                        yield return new BoardPostion(piecePostion.Row - i, piecePostion.Column - i);
                    }

                    if (piecePostion.Row + i < BoardSize && piecePostion.Column - i >= 0)
                    {
                        yield return new BoardPostion(piecePostion.Row + i, piecePostion.Column - i);
                    }

                    if (piecePostion.Row + i < BoardSize && piecePostion.Column + i < BoardSize)
                    {
                        yield return new BoardPostion(piecePostion.Row + i, piecePostion.Column + i);
                    }

                    if (piecePostion.Row - i >= 0 && piecePostion.Column + i < BoardSize)
                    {
                        yield return new BoardPostion(piecePostion.Row - i, piecePostion.Column + i);
                    }
                }
            }
        }
    }
}
