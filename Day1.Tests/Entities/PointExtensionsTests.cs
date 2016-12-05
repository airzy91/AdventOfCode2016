using Day1.Entities;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Entities
{
    public class PointExtensionsTests
    {
        public Fixture AutoFixture { get; set; }

        public PointExtensionsTests()
        {
            AutoFixture = new Fixture();
        }

        [Theory]
        [InlineData(Point.North, Point.West, Direction.Left)]
        [InlineData(Point.East, Point.North, Direction.Left)]
        [InlineData(Point.South, Point.East, Direction.Left)]
        [InlineData(Point.West, Point.South, Direction.Left)]
        [InlineData(Point.North, Point.East, Direction.Right)]
        [InlineData(Point.East, Point.South, Direction.Right)]
        [InlineData(Point.South, Point.West, Direction.Right)]
        [InlineData(Point.West, Point.North, Direction.Right)]
        public void WhenTurn(Point subject, Point expected, Direction direction)
        {
            var result = subject.Turn(direction);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(Point.North, Point.West)]
        [InlineData(Point.East, Point.North)]
        [InlineData(Point.South, Point.East)]
        [InlineData(Point.West, Point.South)]
        public void WhenTurnLeft(Point subject, Point expected)
        {
            var result  = subject.TurnLeft();

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(Point.North, Point.East)]
        [InlineData(Point.East, Point.South)]
        [InlineData(Point.South, Point.West)]
        [InlineData(Point.West, Point.North)]
        public void WhenTurnRight(Point subject, Point expected)
        {
            var result  = subject.TurnRight();

            result.Should().Be(expected);
        }
    }
}