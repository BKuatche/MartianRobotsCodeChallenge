using RobotsCodeChallenges.Enums;

namespace RobotsCodeChallenges.Helpers
{
    public class PositionHelpers
    {
        // clockwise
        public static DirectionType TurnRight(DirectionType direction)
        {
            if (direction == DirectionType.North)
                return DirectionType.East;
            else if (direction == DirectionType.East)
                return DirectionType.South;
            else if (direction == DirectionType.South)
                return DirectionType.West;
            else return DirectionType.North;
        }


        public static DirectionType TurnLeft(DirectionType direction)
        {
            if (direction == DirectionType.North)
                return DirectionType.West;
            else if (direction == DirectionType.West)
                return DirectionType.South;
            else if (direction == DirectionType.South)
                return DirectionType.East;
            else return DirectionType.North;
        }

        public static (int newPositionX, int newPositionY) GetMove(int initialX, int initialY, int diretionX, int directionY)
        {
            return (initialX + diretionX, initialY + directionY);
        }


        public static (int x, int y) GetStepFromDirection(DirectionType direction)
        {
            int x = 0; int y = 0;
            if (direction == DirectionType.North)
                return (x, y + 1);
            else if (direction == DirectionType.East)
                return (x + 1, y);
            else if (direction == DirectionType.South)
                return (x, y - 1);
            else return (x - 1, y);

        }
    }
}
