using RobotsCodeChallenges.Enums;
using RobotsCodeChallenges.Helpers;
using RobotsCodeChallenges.Models;

namespace RobotsCodeChallenges.Tests.UnitTests
{
    [TestFixture]
    public class ScentsTests
    {
        /// <summary>
        ///  More Unit Tests Can be added to covered other edge cases 
        /// </summary>
        [Test]
        public void IsRobotOutsideTheRectangle_ReturnsFalse_ForPointInside()
        {
            Assert.False(ScentsHelpers.IsRobotOutsideTheRectangle(2, 2, 5, 3));
        }

        [Test]
        public void IsRobotOutsideTheRectangle_ReturnsFalse_ForPointOnEdge()
        {
            Assert.False(ScentsHelpers.IsRobotOutsideTheRectangle(5, 3, 5, 3));
            Assert.False(ScentsHelpers.IsRobotOutsideTheRectangle(0, 0, 5, 3));
        }

        [Test]
        public void IsRobotOutsideTheRectangle_ReturnsTrue_ForPointOutside()
        {
            Assert.True(ScentsHelpers.IsRobotOutsideTheRectangle(-1, 0, 5, 3));
            Assert.True(ScentsHelpers.IsRobotOutsideTheRectangle(0, -1, 5, 3));
        }

        [Test]
        public void Forward_Move_UpdatesCoordinates_WhenInsideBounds()
        {
            var data = new TestData
            {
                InitalX = 1,
                InitalY = 1,
                DirectionType = DirectionType.North,
                InstructionType = InstructionType.Forward,
                MaxX = 5,
                MaxY = 3
            };

            bool lost = ScentsHelpers.ScentsRunner(data);

            Assert.False(lost);
            Assert.That(data.InitalX, Is.EqualTo(1));
            Assert.That(data.InitalY, Is.EqualTo(2)); 
        }

        [Test]
        public void Forward_Move_SetsLostAndLeavesScent_WhenSteppingOffGrid()
        {
            var td = new TestData
            {
                InitalX = 5,
                InitalY = 3,
                DirectionType = DirectionType.North,
                InstructionType = InstructionType.Forward,
                MaxX = 5,
                MaxY = 3
            };

            bool lost = ScentsHelpers.ScentsRunner(td);

            Assert.True(lost);
            Assert.That(ScentsHelpers.Scents.Contains("5 3 North"), Is.True);
        }
    }
}
