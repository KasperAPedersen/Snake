using OOP2SOP;
using System.Drawing;
using System.Threading;


CMap.Draw();
CPlayer p1 = new CPlayer();
p1.Start();

bool Running = true;
while(Running)
{
    Thread.Sleep(500);
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.LeftArrow:
            p1.Direction = 'l';
            break;
        case ConsoleKey.RightArrow:
            p1.Direction = 'r';
            break;
        case ConsoleKey.UpArrow:
            p1.Direction = 'u';
            break;
        case ConsoleKey.DownArrow:
            p1.Direction = 'd';
            break;
    }
}