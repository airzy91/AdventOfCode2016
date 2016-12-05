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
    public class FollowInstructionsTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public FollowInstructionsTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenFollow()
        {
            var subject = Mocker.CreateInstance<FollowInstructions>();
            var startingPosition = AutoFixture.Create<Position>();
            var instructions = AutoFixture.CreateMany<Instruction>().ToList();
            var positionsByIntrustions = instructions.ToDictionary(ins => ins, ins => AutoFixture.Create<Position>());
            Mocker.GetMock<IFollowInstruction>()
                .Setup(fi => fi.Follow(It.IsAny<Position>(), It.Is<Instruction>(ins => instructions.Contains(ins))))
                .Returns<Position, Instruction>((pos, ins) => positionsByIntrustions[ins]);

            var result = subject.Follow(startingPosition, instructions);

            result.Should().Be(positionsByIntrustions.Last().Value);
        }
    }
}