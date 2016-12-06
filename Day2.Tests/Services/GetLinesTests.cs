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
    public class GetLinesTests
    {
        public AutoMocker Mocker { get; set; }
        public Fixture AutoFixture { get; set; }

        public GetLinesTests()
        {
            Mocker = new AutoMocker();
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenGet()
        {
            var subject = Mocker.CreateInstance<GetLines>();
            var inputs = AutoFixture.CreateMany<string>().ToList();
            var linesByInput = inputs.ToDictionary(input => input, input => AutoFixture.Create<Line>());
            Mocker.GetMock<IGetLine>()
                .Setup(igl => igl.Get(It.Is<string>(s => inputs.Contains(s))))
                .Returns<string>(s => linesByInput[s]);

            var result = subject.Get(inputs);

            result.Should().Equal(linesByInput.Values);
        }
    }
}