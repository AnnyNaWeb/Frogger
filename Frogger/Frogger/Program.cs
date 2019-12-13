using System;
using System.Threading;

namespace Frogger
{
#if WINDOWS || XBOX
    static class Program
    {
       
        static void Main(string[] args)
        {
            
            Thread t = new Thread(new ThreadStart(Teste));
            t.Start();
            using (Game1 game = new Game1())
            {
                game.Run();
            }
            
        }
       public static void Teste()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Thread {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
#endif
}

