using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2SOP
{
    internal static class CMap
    {
        public static Point Position { get; set; } = new Point(15, 7);
        public static Point Dimensions { get; set; } = new Point(50, 25);
        public static Point GoalPosition { get; set; }

        static internal void Draw()
        {
            for(int i = 0; i < Dimensions.Y; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.Write("X" + string.Concat(Enumerable.Repeat(i == 0 || i == Dimensions.Y - 1 ? "X" : " ", Dimensions.X - 2)) + "X");
            }

            Console.SetCursorPosition(5, Console.WindowHeight - 1);
        }

        static internal void Score(int _new)
        {
            Console.SetCursorPosition(Position.X, Position.Y + Dimensions.Y);
            Console.Write(string.Concat(Enumerable.Repeat(" ", Dimensions.X)));

            Console.SetCursorPosition(Position.X, Position.Y + Dimensions.Y);
            Console.Write($"> Score: {_new}");
        }

        static internal void State(string _new)
        {
            Console.SetCursorPosition(Position.X, Position.Y + Dimensions.Y + 1);
            Console.Write(string.Concat(Enumerable.Repeat(" ", Dimensions.X)));

            Console.SetCursorPosition(Position.X, Position.Y + Dimensions.Y + 1);
            Console.Write($"> State: {_new}");
        }

        static internal void SetGoal()
        {
            Random random = new Random();
            GoalPosition = new Point(random.Next(1, CMap.Dimensions.X - 3), random.Next(1, CMap.Dimensions.Y - 3));

            Console.SetCursorPosition(Position.X + GoalPosition.X + 1, Position.Y + GoalPosition.Y + 1);
            Console.Write("O");
        }
    }
}
