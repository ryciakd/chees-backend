using Api.Model;
using System.Collections.Generic;

namespace UnitTests.Services.Logic.Strategies
{
    public class PieceStrategyTestBase
    {
        protected const int BoardSize = 8;
        protected IEnumerable<BoardPostion> GenerateVerticalPositions(BoardPostion postion)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if(i != postion.Row)
                {
                    yield return new BoardPostion(i, postion.Column);
                }
            }
        }

        protected IEnumerable<BoardPostion> GenerateHorizontalPositions(BoardPostion postion)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (i != postion.Column)
                {
                    yield return new BoardPostion(postion.Row, i);
                }
            }
        }

        protected IEnumerable<BoardPostion> GenerateDiagonalPositions(BoardPostion postion)
        {
            for (int i = 1; i < BoardSize; i++)
            {
                if (postion.Row - i >= 0 && postion.Column - i >= 0)
                {
                    yield return new BoardPostion(postion.Row - i, postion.Column - i);
                }

                if (postion.Row + i < BoardSize && postion.Column - i >= 0)
                {
                    yield return new BoardPostion(postion.Row + i, postion.Column - i);
                }

                if (postion.Row + i < BoardSize && postion.Column + i < BoardSize)
                {
                    yield return new BoardPostion(postion.Row + i, postion.Column + i);
                }

                if (postion.Row - i >= 0 && postion.Column + i < BoardSize)
                {
                    yield return new BoardPostion(postion.Row - i, postion.Column + i);
                }
            }
        }
    }
}
