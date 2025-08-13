using RobotsCodeChallenges.Enums;

namespace RobotsCodeChallenges.Models
{
    public class TestData
    {
        public InstructionType InstructionType { get; set; }
        public DirectionType DirectionType { get; set; }
        public int InitalX { get; set; }
        public int InitalY { get; set; }
        public int MaxY { get; set; }
        public int MaxX { get; set; }
    }
}
