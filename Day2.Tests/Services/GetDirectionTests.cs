using System;
using Day2.Entities;
using Day2.Services;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day2.Tests.Services
{
    public class GetDirectionTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public GetDirectionTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Theory]
        [InlineData('U', Direction.Up)]
        [InlineData('D', Direction.Down)]
        [InlineData('L', Direction.Left)]
        [InlineData('R', Direction.Right)]
        public void WhenGetAndExpectedChar(char input, Direction expected)
        {
            var subject = Mocker.CreateInstance<GetDirection>();

            var result = subject.Get(input);

            result.Should().Be(expected);
        }

        [Fact]
        public void WhenGetAndUnexpectedChar()
        {
            var subject = Mocker.CreateInstance<GetDirection>();
            var input = AutoFixture.Create<int>().ToString()[0];

            Assert.Throws<ArgumentOutOfRangeException>(() => subject.Get(input));
        }
    }
}