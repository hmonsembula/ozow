using FluentAssertions;
using NUnit.Framework;
using Ozow.Assessment.QuestionTwo.Rules;

namespace Ozow.Assessment.Tests
{
    public class GameOfLifeTests
    {
        private IRulesEngine _rulesEngine;
        [SetUp]
        public void Setup()
        {
            _rulesEngine = new GameOfLifeRulesEngine();
        }

        [TestCase(1, true, false)]
        [TestCase(1, false, false)]
        public void Less_Than_Two_Neibours_Should_Die(int neighbourCount, bool isAlive, bool shouldLive)
        {
            //Act
            var isSafe = _rulesEngine.ShouldLive(isAlive, neighbourCount);

            //Assert
            isSafe.Should().Be(shouldLive);
        }

        [TestCase(2, false, false)]
        public void Cell_With_Two_Neighbours_Should_Die_If_Not_Alive(int neighbourCount, bool isAlive, bool shouldLive)
        {
            //Act
            var isSafe = _rulesEngine.ShouldLive(isAlive, neighbourCount);

            //Assert
            isSafe.Should().Be(shouldLive);
        }

        [TestCase(2, true, true)]
        public void Cell_With_Two_Neighbours_Should_Live_If_Alive_Alive(int neighbourCount, bool isAlive, bool shouldLive)
        {
            //Act
            var isSafe = _rulesEngine.ShouldLive(isAlive, neighbourCount);

            //Assert
            isSafe.Should().Be(shouldLive);
        }

        [TestCase(3, true, true)]
        [TestCase(3, false, true)]
        public void Cell_With_Three_Neighbours_Should_Live_Regardless_Of_State(int neighbourCount, bool isAlive, bool shouldLive)
        {
            //Act
            var isSafe = _rulesEngine.ShouldLive(isAlive, neighbourCount);

            //Assert
            isSafe.Should().Be(shouldLive);
        }

        [TestCase(4, true, false)]
        [TestCase(4, false, false)]
        public void More_Than_Three_Neibours_Should_Die(int neighbourCount, bool isAlive, bool shouldLive)
        {
            //Act
            var isSafe = _rulesEngine.ShouldLive(isAlive, neighbourCount);

            //Assert
            isSafe.Should().Be(shouldLive);
        }
    }
}