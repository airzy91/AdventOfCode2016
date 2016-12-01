using System;
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
    public class GetInstructionsTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public GetInstructionsTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGet()
        {
            AutoFixture.Register(() => Guid.NewGuid().ToString().Substring(0, 1));
            var subject = Mocker.CreateInstance<GetInstructions>();
            var instructions = AutoFixture.CreateMany<Instruction>();
            var instructionsDictionary = instructions.ToDictionary(ins => $"{ins.Direction}{ins.Distance}", ins => ins);
            var input = string.Join(", ", instructionsDictionary.Keys);
            Mocker.GetMock<IGetInstruction>()
                .Setup(gi => gi.Get(It.IsAny<string>()))
                .Returns<string>(s => instructionsDictionary[s]);

            var result = subject.Get(input);

            result.Should().Equal(instructionsDictionary.Values);
        }
    }
}