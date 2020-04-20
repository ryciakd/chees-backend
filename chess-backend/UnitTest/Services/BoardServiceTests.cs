using Api.Common;
using Api.Model;
using Api.Services;
using Api.Services.Logic;
using Api.Services.Logic.Strategies;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    class BoardServiceTests
    {

        [Test]
        public void ConstructorShouldValidateParams()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BoardService(null));
        }

        [Test]
        [TestCase(PieceType.Queen)]
        [TestCase(PieceType.Rook)]
        public void GetAvailableMovesShouldReturnAvailableMoves(PieceType pieceType)
        {
            //Arrange
            var postion = new BoardPostion(1, 1);
            var factoryMock = new Mock<IPieceStrategyFactory>();
            var pieceStrategyMock = new Mock<IPieceStrategy>();

            factoryMock
                .Setup(x => x.Create(It.IsAny<PieceType>()))
                .Returns(pieceStrategyMock.Object);

            var uut = new BoardService(factoryMock.Object);

            //Act
            var result = uut.GetAvailableMoves(pieceType, postion);

            //Arrange
            pieceStrategyMock.Verify(x => x.GetAvailableMovesAsync(postion), Times.Once);
        }

        [Test]
        [TestCase(PieceType.Queen)]
        [TestCase(PieceType.Rook)]
        public void GetAvailableMovesShouldReturnNull(PieceType pieceType)
        {
            //Arrange
            var postion = new BoardPostion(1, 1);
            var factoryMock = new Mock<IPieceStrategyFactory>();
            var pieceStrategyMock = new Mock<IPieceStrategy>();

            factoryMock
                .Setup(x => x.Create(It.IsAny<PieceType>()))
                .Returns<IPieceStrategyFactory>(null);

            var uut = new BoardService(factoryMock.Object);

            //Act
            var result = uut.GetAvailableMoves(pieceType, postion).Result;

            //Arrange
            Assert.IsNull(result);
        }

        [Test]
        [TestCase(PieceType.Queen)]
        [TestCase(PieceType.Rook)]
        public void CheckMoveShouldReturnOk(PieceType pieceType)
        {
            //Arrange
            var postionFrom = new BoardPostion(1, 1);
            var postionTo = new BoardPostion(3, 4);
            var factoryMock = new Mock<IPieceStrategyFactory>();
            var pieceStrategyMock = new Mock<IPieceStrategy>();

            pieceStrategyMock
                .Setup(x => x.GetAvailableMovesAsync(postionFrom))
                .Returns(Task.FromResult<IEnumerable<BoardPostion>>(new []{ postionTo }));

            factoryMock
                .Setup(x => x.Create(It.IsAny<PieceType>()))
                .Returns(pieceStrategyMock.Object);

            var uut = new BoardService(factoryMock.Object);

            //Act
            var result = uut.CheckMove(pieceType, postionFrom, postionTo).Result;

            //Arrange
            Assert.That(result.Equals(MoveCheckStatus.Ok));
        }

        [TestCase(PieceType.Queen)]
        [TestCase(PieceType.Rook)]
        public void CheckMoveShouldReturnInvalid(PieceType pieceType)
        {
            //Arrange
            var postionFrom = new BoardPostion(1, 1);
            var postionTo = new BoardPostion(3, 4);
            var factoryMock = new Mock<IPieceStrategyFactory>();
            var pieceStrategyMock = new Mock<IPieceStrategy>();

            pieceStrategyMock
                .Setup(x => x.GetAvailableMovesAsync(postionFrom))
                .Returns(Task.FromResult<IEnumerable<BoardPostion>>(new[] { new BoardPostion(0,0) }));

            factoryMock
                .Setup(x => x.Create(It.IsAny<PieceType>()))
                .Returns(pieceStrategyMock.Object);

            var uut = new BoardService(factoryMock.Object);

            //Act
            var result = uut.CheckMove(pieceType, postionFrom, postionTo).Result;

            //Arrange
            Assert.That(result.Equals(MoveCheckStatus.Invalid));
        }

        [TestCase(PieceType.Queen)]
        [TestCase(PieceType.Rook)]
        public void CheckMoveShouldReturnError(PieceType pieceType)
        {
            //Arrange
            var postionFrom = new BoardPostion(1, 1);
            var postionTo = new BoardPostion(3, 4);
            var factoryMock = new Mock<IPieceStrategyFactory>();
            var pieceStrategyMock = new Mock<IPieceStrategy>();

            pieceStrategyMock
                .Setup(x => x.GetAvailableMovesAsync(postionFrom))
                .Returns(Task.FromResult<IEnumerable<BoardPostion>>(null));

            factoryMock
                .Setup(x => x.Create(It.IsAny<PieceType>()))
                .Returns(pieceStrategyMock.Object);

            var uut = new BoardService(factoryMock.Object);

            //Act
            var result = uut.CheckMove(pieceType, postionFrom, postionTo).Result;

            //Arrange
            Assert.That(result.Equals(MoveCheckStatus.Error));
        }
    }
}
