using System;

namespace Less3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Stroka = Console.ReadLine();
            string Stroka2 = "";
            for (int i = Stroka.Length - 1; i >= 0; i--)
            {
                Stroka2 += Stroka[i]; 
            }
            Console.WriteLine(Stroka2);
            Console.ReadKey();
        }
    }
}
