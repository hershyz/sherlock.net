using System;

namespace sherlock
{
    class Program
    {
        static Sherlock sherlock = new Sherlock();

        static void Main(string[] args)
        {
            sherlock.start(args[0]);
        }
    }
}