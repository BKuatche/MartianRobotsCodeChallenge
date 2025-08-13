using RobotsCodeChallenges.Enums;
using RobotsCodeChallenges.Helpers;

namespace RobotsCodeChallenges.Tests.UnitTests
{
    [TestFixture]
    public class PositionTests
    {

        [TestCase(2, 3, 1, 0, 3, 3, TestName = "Move East (+1,0)")]
        [TestCase(2, 3, 0, 1, 2, 4, TestName = "Move North (0,+1)")]
        [TestCase(2, 3, 0, -1, 2, 2, TestName = "Move South (0,-1)")]
        [TestCase(2, 3, -1, 0, 1, 3, TestName = "Move West (-1,0)")]
        [TestCase(0, 0, 0, 0, 0, 0, TestName = "No movement (0,0)")]
        public void GetMove_ShouldReturnCorrectPostion(
           int initialX, int initialY, int dx, int dy,
           int expectedX, int expectedY)
        {
            // Act
            var (nx, ny) = PositionHelpers.GetMove(initialX, initialY, dx, dy);
            
            //Assert
            Assert.That(nx, Is.EqualTo(expectedX));
            Assert.That(ny, Is.EqualTo(expectedY));
        }


        [TestCase(DirectionType.North, 0, 1)]
        [TestCase(DirectionType.East, 1, 0)]
        [TestCase(DirectionType.South, 0, -1)]
        [TestCase(DirectionType.West, -1, 0)]
        public void GetStepFromDirection_ShouldReturnsCorrectPostions(DirectionType dir, int expDx, int expDy)
        {
            // Act
            var (dx, dy) = PositionHelpers.GetStepFromDirection(dir);
          
            //Assert
            Assert.That(dx, Is.EqualTo(expDx));
            Assert.That(dy, Is.EqualTo(expDy));
        }


        [Test]
        public void TurnRight_RotatesClockwise_ShouldReturnValidDirection()
        {
            Assert.That(PositionHelpers.TurnRight(DirectionType.North), Is.EqualTo(DirectionType.East));
            Assert.That(PositionHelpers.TurnRight(DirectionType.East), Is.EqualTo(DirectionType.South));
            Assert.That(PositionHelpers.TurnRight(DirectionType.South), Is.EqualTo(DirectionType.West));
            Assert.That(PositionHelpers.TurnRight(DirectionType.West), Is.EqualTo(DirectionType.North));
        }

        [Test]
        public void TurnLeft_RotatesCounterClockwise_ShouldReturnValidDirection()
        {
            //Assert
            Assert.That(PositionHelpers.TurnLeft(DirectionType.North), Is.EqualTo(DirectionType.West));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.West), Is.EqualTo(DirectionType.South));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.South), Is.EqualTo(DirectionType.East));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.East), Is.EqualTo(DirectionType.North));
        }
    }
}
