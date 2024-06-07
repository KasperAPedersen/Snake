using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP2SOP
{
    internal class CPlayer
    {
        Point Position { get; set; } = new Point(0, 0);
        public char Direction { get; set; } = 'r';
        int playerScore = 0;

        public CPlayer()
        {
            DrawPlayerPosition();
            CMap.Score(playerScore);
            CMap.State("Waiting");
            CMap.SetGoal();
        }

        internal void DrawPlayerPosition()
        {
            Console.SetCursorPosition(CMap.Position.X + Position.X + 1, CMap.Position.Y + Position.Y + 1);
            Console.Write("X");

            Console.SetCursorPosition(5, Console.WindowHeight - 1);
        }

        internal void RemoveOldPlayerPosition()
        {
            Console.SetCursorPosition(CMap.Position.X + Position.X + 1, CMap.Position.Y + Position.Y + 1);
            Console.Write(" ");
        }

        internal void Start()
        {
            Thread pThread = new Thread(new ThreadStart(() =>
            {
                CMap.State("In game");

                bool Running = true;
                int speed = 100;
                while(Running)
                {
                    Thread.Sleep(speed);

                    RemoveOldPlayerPosition();
                    Console.Title = $"Dir: {Direction} | {Position.X}/{Position.Y} | {CMap.GoalPosition.X}/{CMap.GoalPosition.Y}";

                    switch(Direction)
                    {
                        case 'r':
                            Position = new Point(Position.X + 1, Position.Y);
                            speed = 50;
                            break;
                        case 'l':
                            Position = new Point(Position.X - 1, Position.Y);
                            speed = 50;
                            break;
                        case 'u':
                            Position = new Point(Position.X, Position.Y - 1);
                            speed = 100;
                            break;
                        case 'd':
                            Position = new Point(Position.X, Position.Y + 1);
                            speed = 100;
                            break;
                    }

                    if(Position.X < 0)
                    {
                        Position = new Point(CMap.Dimensions.X - 3, Position.Y);
                        Running = false;
                    }

                    if(Position.X > CMap.Dimensions.X - 3)
                    {
                        Position = new Point(0, Position.Y);
                        Running = false;
                    }

                    if(Position.Y < 0)
                    {
                        Position = new Point(Position.X, CMap.Dimensions.Y - 3);
                        Running = false;
                    }

                    if(Position.Y > CMap.Dimensions.Y - 3)
                    {
                        Position = new Point(Position.X, 0);
                        Running = false;
                    }

                    if(Position.X == CMap.GoalPosition.X && Position.Y == CMap.GoalPosition.Y)
                    {
                        CMap.Score(playerScore += 1);
                        CMap.SetGoal();
                    }

                    DrawPlayerPosition();
                }

                CMap.State("Game over");
            }));
            pThread.Start();
        }
    }
}
