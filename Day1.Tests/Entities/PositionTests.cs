using System.Linq;
using Day1.Entities;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Entities
{
    public class PositionTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public PositionTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGetNewPosition()
        {
            var subject = AutoFixture.Create<Position>();
            var instruction = AutoFixture.Create<Instruction>();
            var expectedPoint = subject.Point.Turn(instruction.Direction);
            var expectedCoordinate = subject.Coordinate.GetNewCoordinate(expectedPoint, instruction.Distance);
            var expectedPreviousCoordinates = subject.Coordinate.GetCoordinatesBetween(expectedPoint,
                instruction.Distance);
            var previousLength = subject.PreviousCoordinates.Count + instruction.Distance;


            var result = subject.GetNewPosition(instruction);

            result.Point.Should().Be(expectedPoint);
            result.Coordinate.X.Should().Be(expectedCoordinate.X);
            result.Coordinate.Y.Should().Be(expectedCoordinate.Y);
            result.PreviousCoordinates.Count.Should().Be(previousLength);
            result.PreviousCoordinates.Count(
                    coord => subject.PreviousCoordinates.Any(prev => prev.X == coord.X && prev.Y == coord.Y))
                .Should()
                .Be(subject.PreviousCoordinates.Count);
            result.PreviousCoordinates.Any(coord => coord.X == subject.Coordinate.X && coord.Y == subject.Coordinate.Y)
                .Should()
                .BeTrue();
            result.PreviousCoordinates.Count(
                    coord => expectedPreviousCoordinates.Any(prev => prev.X == coord.X && prev.Y == coord.Y))
                .Should()
                .Be(expectedPreviousCoordinates.Count);
        }
    }
}