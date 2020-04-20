using Api.Model;
using Api.Services.Logic.Strategies;
using NUnit.Framework;
using System.Linq;
using UnitTests.Services.Logic.Strategies;

namespace UnitTest
{
    public class QueenStrategyTests : PieceStrategyTestBase
    {
        private QueenStrategy uut;

        [OneTimeSetUp]
        public void Setup()
        {
            uut = new QueenStrategy();
        }

        [Test] 
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        //TODO: and so on for all board postions
        public void GetAvailableMovesShouldReturnCorrectMoves(int rowFrom, int columntFrom)
        {
            // Arrange
            var from = new BoardPostion(rowFrom, columntFrom);
            var legalMoves = GenerateDiagonalPositions(from)
                .Union(GenerateHorizontalPositions(from))
                .Union(GenerateVerticalPositions(from))
                .ToList();

            // Act
            var moves = uut.GetAvailableMovesAsync(from).Result.ToList();

            // Assert
            foreach (var move in moves)
            {
                Assert.Contains(move, legalMoves);
            }

            foreach (var move in legalMoves)
            {
                Assert.Contains(move, moves);
            }
        }
    }
}