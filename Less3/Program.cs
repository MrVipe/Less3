using System;

namespace Less3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Mass = new int[10, 10];
            for (int i = 0; i < Mass.GetLength(0); i++)
            {
                for (int j = 0; j < Mass.GetLength(1); j++)
                {
                    Mass[i, j] = i + j;
                    if (i == j) Console.WriteLine(Mass[i, j]);
                }
            }

            Console.ReadKey();
        }
    }
}
