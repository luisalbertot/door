using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using knockknock.readify.net;

namespace door
{
    public static class BluePill
    {

        public static ContactDetails WhoAreYou()
        {
            return new ContactDetails()
            {
                EmailAddress = "luisalbertot@gmail.com",
                GivenName = "Luis Alberto",
                FamilyName = "Tchakerian",
                PhoneNumber = "0402261117"
            };
        }

        public static long Fibonnaci(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                /*
                    //F_n = F_{n-1} + F_{n-2},
                    return fbn(n - 1) + fbn(n - 2);
                }*/

                //Flat
                long i, fib0, fib1, nAbs = Math.Abs(n);
                fib0 = 0;
                fib1 = 1;
                for (i = 1; i <= nAbs; i++)
                {
                    fib0 += fib1;
                    fib1 = fib0 - fib1;
                }

                if (n < 0 && (!(n % 2 == 1))) { fib0 = -fib0; }
                return fib0;

            }
        }
        public static double FibonnaciAprox(long n)
        {
            //Phi20/sqrt(5)
            double phi = 1.618;
            long nAbs = Math.Abs(n);
            double aprox = Math.Pow(phi, nAbs) / Math.Sqrt(5);
            if (n < 0 && (!(n % 2 == 1))) { aprox = -aprox; }
            return aprox;
        }

        public static TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            TriangleType triangleType = TriangleType.Error;

            long la = a, lb = b, lc = c;

            if (
                (la > 0)
                && (lb > 0)
                && (lc > 0)

                && (la + lb > lc)
                && (lb + lc > la)
                && (lc + la > lb)
                )
            {
                //OK
                triangleType = TriangleType.Scalene;
                if (a == b && b == c)
                {
                    triangleType = TriangleType.Equilateral;
                }
                else if (a == b || b == c || c == a)
                {
                    triangleType = TriangleType.Isosceles;
                }
            }

            return triangleType;
        }

        public static string ReverseWords(string s)
        {
            List<string> reversedWords = new List<string>();
            foreach (string word in s.Split(' '))
            {
                reversedWords.Add(invertString(word));
            }
            return String.Join(" ", reversedWords.ToArray());;
        }

        private static string invertString(string word)
        {
            string drow = "";
            for (int i = word.Length - 1; i >= 0; i--)
            {
                drow += word.Substring(i, 1);
            }
            return drow;
        }

    }
}