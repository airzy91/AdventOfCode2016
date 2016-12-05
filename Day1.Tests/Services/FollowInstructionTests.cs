using System.Linq;
using Day1.Entities;
using Day1.Services;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Services
{
    public class FollowInstructionTests
    {
        public Fixture AutoFxture { get; set; }
        public AutoMocker Mocker { get; set; }

        public FollowInstructionTests()
        {
            AutoFxture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenFollow()
        {
            var subject = Mocker.CreateInstance<FollowInstruction>();
            var position = AutoFxture.Create<Position>();
            var instruction = AutoFxture.Create<Instruction>();
            var expected = position.GetNewPosition(instruction);

            var result = subject.Follow(position, instruction);

            result.Point.Should().Be(expected.Point);
            result.Coordinate.X.Should().Be(expected.Coordinate.X);
            result.Coordinate.Y.Should().Be(expected.Coordinate.Y);
            result.PreviousCoordinates.All(
                prev => expected.PreviousCoordinates.Any(exp => exp.X == prev.X && exp.Y == prev.Y))
                .Should()
                .BeTrue();
        }
    }
}