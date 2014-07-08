﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ackermann
{
    class Program
    {
        private static long _loops = 0;
        private static bool _running = true;

        static void Main()
        {
            const int m = -1;
            const int n = 8;

            Task.Factory.StartNew(PrintCount);

            int result = ack(m, n);
            _running = false;

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Results: {0}", result);
            Console.ReadKey();
        }

        private static int ack(int m, int n)
        {
            Interlocked.Increment(ref _loops);

            int ans;
            if (m == 0)
            {
                ans = n + 1;
            }
            else if (n == 0)
            {
                ans = ack(m - 1, 1);
            }
            else
            {
                ans = ack(m - 1, ack(m, n - 1));
            }

            return ans;
        }

        private static void PrintCount()
        {
            while (_running)
            {
                long loops = Interlocked.Read(ref _loops);
                Console.WriteLine("{0} loops", loops);

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
