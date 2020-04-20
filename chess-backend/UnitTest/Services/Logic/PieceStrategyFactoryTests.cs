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
namespace UnitTests.Services.Logic
{
    public class PieceStrategyFactoryTests
    {
        [Test]
        public void CreateQueenStrategyShouldWork()
        {
            //Arrange
            var uut = new PieceStrategyFactory();

            //Act
            var result = uut.Create(PieceType.Queen);

            //Assert
            Assert.That(result.GetType() == typeof(QueenStrategy));
        }

        [Test]
        public void CreateRookStrategyShouldWork()
        {
            //Arrange
            var uut = new PieceStrategyFactory();

            //Act
            var result = uut.Create(PieceType.Rook);

            //Assert
            Assert.That(result.GetType() == typeof(RookStrategy));
        }
    }
}
