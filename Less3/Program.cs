using System;

namespace Less3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] Mass = new string[10, 10];
            for (int i = 0; i < Mass.GetLength(0); i++)
            {
                for (int j = 0; j < Mass.GetLength(1); j++)
                {
                    Mass[i, j] = "O";
                }
            }

            int CordVector;
            int CordX;
            int CordY;
            int CordX0;
            int CordY0; 
            int CordX9;
            int CordY9;
            bool Ismistake;

            for (int numKolabl = 4; numKolabl >= 1; numKolabl--)
            {
                do
                {
                    //вывод
                    Console.WriteLine();
                    for (int i = -1; i < Mass.GetLength(0); i++)
                    {
                        for (int j = -1; j < Mass.GetLength(1); j++)
                        {
                            if (i == -1 && j != -1)
                            {
                                if (j == Mass.GetLength(1) - 1)
                                    Console.WriteLine(j + " ");
                                else
                                    Console.Write(j + " ");
                            }
                            else if (j == -1 && i != -1)
                            {
                                Console.Write(i + " ");
                            }
                            else if (j == -1 && i == -1)
                            {
                                Console.Write("  ");
                            }
                            else
                            {
                                if (j == Mass.GetLength(1) - 1)
                                    Console.WriteLine(Mass[i, j]);
                                else
                                    Console.Write(Mass[i, j] + " ");
                            }

                        }
                    }
                    Console.WriteLine();
                    do
                    {
                        Ismistake = false;
                        Console.WriteLine("Введите начальные значения координат для " + Convert.ToString(numKolabl) + " палубного корабля (от 0 до 9)");
                        CordX = Convert.ToInt32(Console.ReadLine());
                        CordY = Convert.ToInt32(Console.ReadLine());

                        if ((CordX < 0 || CordX > 9) || (CordY < 0 || CordY > 9)) // проверка на значения
                        {
                            Console.WriteLine("Координаты выходят за границы допустимых значений");
                            Ismistake = true;
                            continue;
                        }
                        if (Mass[CordX, CordY] == "X") // проверка на занятость корабля
                        {
                            Console.WriteLine("Здесь уже размешен другой корабль, выбирете другие координаты");
                            Ismistake = true;
                            continue;
                        }
                        if (CordX - 1 < 0) CordX0 = 0; else CordX0 = CordX - 1;
                        if (CordX + 1 > 9) CordX9 = 9; else CordX9 = CordX + 1;
                        if (CordY - 1 < 0) CordY0 = 0; else CordY0 = CordY - 1;
                        if (CordY + 1 > 9) CordY9 = 9; else CordY9 = CordY - 1;
                        if (Mass[CordX0, CordY] == "X" || Mass[CordX9, CordY] == "X" || Mass[CordX, CordY0] == "X" || Mass[CordX, CordY9] == "X")  // проверка на то, что рядом есть корабль
                        {
                            Console.WriteLine("Опасно размещать этот корабль рядом с другим кораблем - столкновение неизбежно. Выбирете другие координаты");
                            Ismistake = true;
                            continue;
                        }

                    } while (Ismistake == true);

                    do
                    {
                        Ismistake = false;
                        Console.WriteLine("Введите направление корабля  0 - влево, 1 - вправа, 2 - вверх, 3 - вниз");
                        CordVector = Convert.ToInt32(Console.ReadLine());
                        if (CordVector < 0 || CordVector > 3) // проверка на значения
                        {
                            Console.WriteLine("Направление указано не верно");
                            Ismistake = true;
                            continue;
                        }

                        //проверка на направление
                        int CordMass = 0;
                        switch (CordVector)
                        {
                            case 0:
                                CordMass = CordY - numKolabl -1;
                                break;
                            case 1:
                                CordMass = CordY + numKolabl - 1;
                                break;
                            case 2:
                                CordMass = CordX - numKolabl - 1;
                                break;
                            case 3:
                                CordMass = CordX + numKolabl - 1;
                                break;
                        }

                        if (CordMass < 0 || CordMass > 9) // проверка границы
                        {
                            Console.WriteLine("Корабль направляется за пределы границ боевых действий. Выберете другое направление");
                            Ismistake = true;
                            continue;
                        }
                        string KolVal = "O";
                        for (int i = 1; i <= numKolabl; i++)
                        {
                            switch (CordVector)
                            {
                                case 0:
                                    KolVal = Mass[CordX, CordY - i - 1];
                                    break;
                                case 1:
                                    KolVal = Mass[CordX, CordY + i - 1];
                                    break;
                                case 2:
                                    KolVal = Mass[CordX - i - 1, CordY];
                                    break;
                                case 3:
                                    KolVal = Mass[CordX + 1 - 1, CordY];
                                    break;
                            }
                            if (KolVal == "X") // проверка границы
                            {
                                Console.WriteLine("Корабль столкнется с другим кораблем. Выберете другое направление");
                                Ismistake = true;
                                continue;
                            }
                        }

                    }
                    while (Ismistake == true);

                }
                while (Ismistake == true);


                for (int i = 0; i <= numKolabl-1; i++)
                {
                    switch (CordVector)
                    {
                        case 0:
                            Mass[CordX, CordY - i] = "X";
                            break;
                        case 1:
                            Mass[CordX, CordY + i] = "X";
                            break;
                        case 2:
                            Mass[CordX - i, CordY] = "X";
                            break;
                        case 3:
                            Mass[CordX + i, CordY] = "X";
                            break;

                    }
                }
            }


            //вывод
            Console.WriteLine();
            for (int i = -1; i < Mass.GetLength(0); i++)
            {
                for (int j = -1; j < Mass.GetLength(1); j++)
                {
                    if (i == -1 && j != -1)
                    {
                        if (j == Mass.GetLength(1) - 1)
                            Console.WriteLine(j + " ");
                        else
                            Console.Write(j + " ");
                    }
                    else if (j == -1 && i != -1)
                    {
                        Console.Write(i + " ");
                    }
                    else if (j == -1 && i == -1)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        if (j == Mass.GetLength(1) - 1)
                            Console.WriteLine(Mass[i, j]);
                        else
                            Console.Write(Mass[i, j] + " ");
                    }

                }
            }
            Console.WriteLine("Построение кораблей завершено");
            Console.ReadKey();
        }
    }
}
