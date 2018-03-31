

using System;

namespace HomeTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30);

            CustomGame cg = new CustomGame();
            cg.MovePlatformAndBall();
        }
    }
}
