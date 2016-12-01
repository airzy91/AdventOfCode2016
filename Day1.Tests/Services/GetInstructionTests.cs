using Day1.Entities;
using Day1.Services;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Services
{
    public class GetInstructionTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public GetInstructionTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGet()
        {
            AutoFixture.Register(() => AutoFixture.Create<int>() % 2 == 0 ? "R" : "L");
            var subject = Mocker.CreateInstance<GetInstruction>();
            var directionString = AutoFixture.Create<string>();
            var direction = directionString == "R" ? Direction.Right : Direction.Left;
            var distance = AutoFixture.Create<int>();
            var instruction = $"{directionString}{distance}";

            var result = subject.Get(instruction);

            result.Direction.Should().Be(direction);
            result.Distance.Should().Be(distance);
        }
    }
}