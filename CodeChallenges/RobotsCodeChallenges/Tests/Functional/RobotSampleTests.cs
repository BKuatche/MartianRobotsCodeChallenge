using RobotsCodeChallenges.Helpers;

namespace RobotsCodeChallenges.Tests.Functional
{
    public class RobotSampleTests
    {
        [Test]
        public void SampleInput_ShouldReturnExpectedOutput()
        {
            // Arrange
            var input = @"5 3
              1 1 E
              RFRFRFRF
              3 2 N
              FRRFLLFFRRFLL
              0 3 W
              LLFFFLFLFL";

            var expected = @"1 1 E
              3 3 N LOST
              2 3 S";

            // Act
            var actual = ScentsHelpers.ScentsRunnerSimulation(input);

            // Assert
            Assert.That(Normalize(actual), Is.EqualTo(Normalize(expected)));
        }


        private string Normalize(string input) =>
          string.Join("\n",
          input.Replace("\r", "")
           .Split('\n', StringSplitOptions.RemoveEmptyEntries)
           .Select(l => l.Trim()));
    }     
}
