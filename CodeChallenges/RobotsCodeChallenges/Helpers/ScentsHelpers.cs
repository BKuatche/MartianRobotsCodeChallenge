using RobotsCodeChallenges.Enums;
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
    }
}
