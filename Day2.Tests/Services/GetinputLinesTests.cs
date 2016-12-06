using System.Linq;
using Day2.Services;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day2.Tests.Services
{
    public class GetinputLinesTests
    {
        public AutoMocker Mocker { get; set; }
        public Fixture AutoFixture { get; set; }

        public GetinputLinesTests()
        {
            Mocker = new AutoMocker();
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenGet()
        {
            var subject = Mocker.CreateInstance<GetInputLines>();
            var lines = AutoFixture.CreateMany<string>().ToList();
            var input = string.Join("\r\n", lines);

            var result = subject.Get(input);

            result.Should().Equal(lines);
        }
    }
}