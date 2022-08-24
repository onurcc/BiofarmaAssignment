using System;
using System.Collections.Generic;

namespace ParallelLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            List<int> xtmp = new List<int>();
            List<int> ytmp = new List<int>();

            int[,] data = { 
                { 1, 2 },
                { 3, 7 },
                { 0, 6 },
                { 1, 1 },
                { -5, 2 },
                { 1, 5 },
                { 3, -5 },
            };

            for (int i = 0; i < data.Length/2; i++)
            {
                for (int j = i+1; j < data.Length/2; j++)
                {
                    if (data[i, 0] == data[j, 0] && !ytmp.Contains(data[j, 0]))
                    {
                        ytmp.Add(data[j, 0]);
                        y++;
                    }
                    else if (data[i, 1] == data[j, 1] && !xtmp.Contains(data[j, 1]))
                    {
                        xtmp.Add(data[j, 1]);
                        x++;
                    }
                }
            }

            Console.WriteLine("X eksenine paralel doğru sayısı: " + x + "\nY eksenine paralel doğru sayısı: " + y);
        }
    }
}

