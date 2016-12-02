using System;
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
            var expectedPont = instruction.Direction == Direction.Left
                ? subject.Point.TurnLeft()
                : subject.Point.TurnRight();
            var expectedY = subject.Y;
            var expectedX = subject.X;
            switch (expectedPont)
            {
                case Point.North:
                    expectedX += instruction.Distance;
                    break;
                case Point.East:
                    expectedY += instruction.Distance;
                    break;
                case Point.South:
                    expectedX -= instruction.Distance;
                    break;
                case Point.West:
                    expectedY -= instruction.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var result = subject.GetNewPosition(instruction);

            result.Point.Should().Be(expectedPont);
            result.X.Should().Be(expectedX);
            result.Y.Should().Be(expectedY);
        }

        [Fact]
        public void WhenDistance()
        {
            var subject = AutoFixture.Create<Position>();
            var expected = Math.Abs(subject.X) + Math.Abs(subject.Y);

            var result = subject.Distance();

            result.Should().Be(expected);
        }
    }
}