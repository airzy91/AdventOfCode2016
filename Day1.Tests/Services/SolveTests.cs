using System.Linq;
using Day1.Entities;
using Day1.Services;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Services
{
    public class SolveTests
    {
        public AutoMocker Mocker { get; set; }
        public Fixture AutoFixture { get; set; }

        public SolveTests()
        {
            Mocker = new AutoMocker();
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenPartOne()
        {
            var subject = Mocker.CreateInstance<Solve>();
            var input = AutoFixture.Create<string>();
            var instructions = AutoFixture.CreateMany<Instruction>().ToList();
            var endPosition = AutoFixture.Create<Position>();
            Mocker.GetMock<IGetInput>().Setup(ige => ige.Get()).Returns(input);
            Mocker.GetMock<IGetInstructions>().Setup(ige => ige.Get(input)).Returns(instructions);
            Mocker.GetMock<IFollowInstructions>()
                .Setup(ife => ife.Follow(
                        It.Is<Position>(
                            pos => pos.Point == Point.North && pos.Coordinate.X == 0 && pos.Coordinate.Y == 0),
                        instructions))
                .Returns(endPosition);

            var result = subject.PartOne();

            result.Should().Be(endPosition.Coordinate.GetDistanceFromZero());
        }
    }
}