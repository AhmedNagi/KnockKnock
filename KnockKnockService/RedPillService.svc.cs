using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KnockKnockService
{
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPillService : IRedPill
    {
        public long FibonacciNumber(long n)
        {
            if (n > 92)
                Fault(new ArgumentOutOfRangeException("Fib(>92) will cause a 64-bit integer overflow."));
            if (n < -92)
                Fault(new ArgumentOutOfRangeException("Fib(<92) will cause a 64-bit integer overflow."));
            if (n == 0) return 0;
            long an = Math.Abs(n);
            long nr = 2;
            long[] result = { 1, 1 };
            long[] tmp = new long[nr];
            for (long i = 1; i < an; i++)
            {
                tmp[0] = result[0] + result[1];
                tmp[1] = result[0];
                Array.Copy(tmp, 0, result, 0, 2);
            }
            return ((n < 0) && (n % 2 == 0)) ? -result[1] : result[1];
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                if (a == b && b == c)
                    return TriangleType.Equilateral;
                else if (a == b || b == c || a == c)
                    return TriangleType.Isosceles;
                else
                    return TriangleType.Scalene;
            }
            else
                return TriangleType.Error;
        }

        public string ReverseWords(string s)
        {
            if (s == null)
                Fault(new ArgumentNullException("Value cannot be null."));
            return string.Join(" ", s.Split(' ').Select(x => new String(x.Reverse().ToArray())));
        }

        private void Fault<T>(T detail) where T : Exception
        {
            throw new FaultException<T>(detail, detail.Message);
        }

        public Guid WhatIsYourToken()
        {
            return Guid.Parse("0da122f7-74b2-42db-be5c-e906ff4efc3d");
        }
    }
}
