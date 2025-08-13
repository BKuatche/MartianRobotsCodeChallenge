using RobotsCodeChallenges.Enums;
using RobotsCodeChallenges.Helpers;

namespace RobotsCodeChallenges.Tests.UnitTests
{
    [TestFixture]
    public class PositionTests
    {

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
            Assert.That(PositionHelpers.TurnLeft(DirectionType.North), Is.EqualTo(DirectionType.West));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.West), Is.EqualTo(DirectionType.South));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.South), Is.EqualTo(DirectionType.East));
            Assert.That(PositionHelpers.TurnLeft(DirectionType.East), Is.EqualTo(DirectionType.North));
        }
    }
}
