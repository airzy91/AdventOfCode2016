using System;
using System.Collections.Generic;
using System.Linq;
using Day1.Entities;
using FluentAssertions;
using Moq.AutoMock;
using Ploeh.AutoFixture;
using Xunit;

namespace Day1.Tests.Entities
{
    public class CoordinateExtensionsTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public CoordinateExtensionsTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGetNewCoordinate()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var point = AutoFixture.Create<Point>();
            var distance = AutoFixture.Create<int>();
            var expectedX = subject.X;
            var expectedY = subject.Y;

            switch (point)
            {
                case Point.North:
                    expectedX += distance;
                    break;
                case Point.East:
                    expectedY += distance;
                    break;
                case Point.South:
                    expectedX -= distance;
                    break;
                case Point.West:
                    expectedY -= distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var result = subject.GetNewCoordinate(point, distance);

            result.X.Should().Be(expectedX);
            result.Y.Should().Be(expectedY);
        }

        [Fact]
        public void WhenGetCoordinatesBetween()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var point = AutoFixture.Create<Point>();
            var distance = AutoFixture.Create<int>();

            var expectedCoords = new List<Coordinate>();
            for (var i = 1; i < distance; i++)
            {
                expectedCoords.Add(subject.GetNewCoordinate(point, i));
            }

            var result = subject.GetCoordinatesBetween(point, distance);

            result.All(coord => expectedCoords.Any(ex => ex.X == coord.X && ex.Y == coord.Y)).Should().BeTrue();
            result.Count.Should().Be(distance -1);
        }

        [Fact]
        public void WhenGetDistanceFromZero()
        {
            var subject = AutoFixture.Create<Coordinate>();
            var expected = Math.Abs(subject.X) + Math.Abs(subject.Y);

            var result = subject.GetDistanceFromZero();

            result.Should().Be(expected);
        }
    }
}