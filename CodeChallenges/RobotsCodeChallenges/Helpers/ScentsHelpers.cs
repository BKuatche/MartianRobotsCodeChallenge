using RobotsCodeChallenges.Enums;
using RobotsCodeChallenges.Extensions;
using RobotsCodeChallenges.Models;

namespace RobotsCodeChallenges.Helpers
{
    public class ScentsHelpers
    {
        public static readonly HashSet<string> Scents = new();

        public static bool IsRobotOutsideTheRectangle(int x, int y, int maxX, int MaxY)
        {
            return x < 0 || y < 0 || x > maxX || y > MaxY;
        }

        public static bool ScentsRunner(TestData testData)
        {
            if (testData.InstructionType == InstructionType.Left)
            {
                testData.DirectionType = PositionHelpers.TurnLeft(testData.DirectionType);
                return false;
            }
            if (testData.InstructionType == InstructionType.Right)
            {
                testData.DirectionType = PositionHelpers.TurnRight(testData.DirectionType);
                return false;
            }
            if (testData.InstructionType == InstructionType.Forward)
            {
                var (x, y) = PositionHelpers.GetStepFromDirection(testData.DirectionType);
                int nextX = testData.InitalX + x;
                int nextY = testData.InitalY + y;

                string scentKey = Scent(testData.InitalX, testData.InitalY, testData.DirectionType);

                if (IsRobotOutsideTheRectangle(nextX, nextY, testData.MaxX, testData.MaxY) && Scents.Contains(scentKey))
                {
                    return false;
                }

                if (IsRobotOutsideTheRectangle(nextX, nextY, testData.MaxX, testData.MaxY))
                {
                    Scents.Add(scentKey);
                    return true;
                }

                var (mx, my) = PositionHelpers.GetMove(testData.InitalX, testData.InitalY, x, y);
                testData.InitalX = mx;
                testData.InitalY = my;
                return false;
            }

            Console.WriteLine(" Command does not exist");
            return false;
        }

        public static string Scent(int x, int y, DirectionType direction)
        {
            return $"{x} {y} {direction}";
        }

        public string ScentsRunnerSimulation(string input)
        {
            var outcome = new List<string>();

            var lines = input.Replace("\r", "")
                           .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => s.Trim())
                           .ToList();

            var maxPositions = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int maxX = int.Parse(maxPositions[0]);
            int maxY = int.Parse(maxPositions[1]);

            for (int i = 1; i < lines.Count; i += 2)
            {
                var postions = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int initialX = int.Parse(postions[0]);
                int intialy = int.Parse(postions[1]);

                // best pratice add check to verify if command does not exist
                var direction = EnumExtensions.FromDescription<DirectionType>(postions[2]);

                string instructions = lines[i + 1];


                var testData = new TestData
                {
                    InitalX = initialX,
                    InitalY = intialy,
                    DirectionType = direction,
                    MaxX = maxX,
                    MaxY = maxY
                };

                bool lost = false;

                foreach (char instruction in instructions)
                {
                    // best pratice add method to verify if command does not exist
                    testData.InstructionType = EnumExtensions.FromDescription<InstructionType>(instruction.ToString());
                    lost = ScentsRunner(testData);
                    if (lost) break;
                }


                string line = $"{testData.InitalX} {testData.InitalY} {((Enum)(object)testData.DirectionType).GetDescription()}" + (lost ? " LOST" : "");
                outcome.Add(line);
            }
            return string.Join(Environment.NewLine, outcome);
        }
    }
}
