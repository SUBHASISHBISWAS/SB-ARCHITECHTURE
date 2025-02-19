﻿using System;

namespace Demo
{
    class Program
    {

        static int GetControlDigit(long number)
        {

            int sum = 0;
            bool isOddPos = true;

            while (number > 0)
            {

                int digit = (int) (number%10);

                if (isOddPos)
                    sum += 3 * digit;
                else
                    sum += digit;

                number /= 10;
                isOddPos = !isOddPos;

            }

            int modulo = sum%7;

            return modulo;

        }

        static void Main(string[] args)
        {

            Console.ReadLine();

        }
    }
}
