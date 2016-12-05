using Day1.Entities;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Entities
{
    public class CoordinateTests
    {
        public Fixture AutoFixture { get; set; }

        public CoordinateTests()
        {
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenEqualsAndNull()
        {
            var subject = AutoFixture.Create<Coordinate>();

            var result = subject.Equals(null);

            result.Should().BeFalse();
        }

        [Fact]
        public void WhenEqualsAndNotCoordinate()
        {
            var subject = AutoFixture.Create<Coordinate>();

            var result = subject.Equals("foo");

            result.Should().BeFalse();
        }

        [Fact]
        public void WhenEqualsAndNotTheSame()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var notTheSame = AutoFixture.Create<Coordinate>();

            var result = subject.Equals(notTheSame);

            result.Should().BeFalse();
        }

        [Fact]
        public void WhenEqualsAndSameCoordinates()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var theSame = new Coordinate(subject.X, subject.Y);

            var result = subject.Equals(theSame);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenEqualsAndSameObject()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var theSame = subject;

            var result = subject.Equals(theSame);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenGetHashCodeAndSame()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var theSame = subject;

            var result = subject.GetHashCode();

            result.Should().Be(theSame.GetHashCode());
        }

        [Fact]
        public void WhenGetHashCodeAndSameCoordinates()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var theSame = new Coordinate(subject.X, subject.Y);

            var result = subject.GetHashCode();

            result.Should().Be(theSame.GetHashCode());
        }

        [Fact]
        public void WhenGetHashCodeAndSameCoordinatesSwapped()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var notTheSame = new Coordinate(subject.Y, subject.X);

            var result = subject.GetHashCode();

            result.Should().NotBe(notTheSame.GetHashCode());
        }

        [Fact]
        public void WhenGetHashCodeAndNotTheSame()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var notTheSame = AutoFixture.Create<Coordinate>();

            var result = subject.GetHashCode();

            result.Should().NotBe(notTheSame.GetHashCode());
        }
    }
}