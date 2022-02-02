using System;

namespace Less3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] Telephone = new string[5,2];

            Telephone[0, 0] = "Федор";
            Telephone[1, 0] = "Павел";
            Telephone[2, 0] = "Артемий";
            Telephone[3, 0] = "Лилия";
            Telephone[4, 0] = "Артемида";
            
            Telephone[0, 1] = "+79851645299/fedor_333@yandex.ru";
            Telephone[1, 1] = "+77931248942/pavel_ggg2@yandex.ru";
            Telephone[2, 1] = "+74597812347/jus34_h33@google.com";
            Telephone[3, 1] = "+78529637416/gss99456@yandex.ru";
            Telephone[4, 1] = "+71234567890/gigui1144@google.com";


            for (int i = 0; i < Telephone.GetLength(0); i++)
            {
                Console.WriteLine(Telephone[i, 0] + "......." + Telephone[i, 1]);
            }

            Console.ReadKey();
        }
    }
}
