using System.Linq;
using Day2.Entities;
using Day2.Services;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day2.Tests.Services
{
    public class GetLineTests
    {
        public AutoMocker Mocker { get; set; }
        public Fixture AutoFixture { get; set; }

        public GetLineTests()
        {
            Mocker = new AutoMocker();
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenGet()
        {
            var subject = Mocker.CreateInstance<GetLine>();
            var input = AutoFixture.Create<string>();
            var directionsByInstruction = input.Distinct().ToDictionary(i => i, i => AutoFixture.Create<Direction>());
            Mocker.GetMock<IGetDirection>()
                .Setup(gd => gd.Get(It.Is<char>(c => directionsByInstruction.ContainsKey(c))))
                .Returns<char>(c => directionsByInstruction[c]);

            var result = subject.Get(input);

            result.Directions.Should().Equal(input.Select(c => directionsByInstruction[c]));
        }
    }
}