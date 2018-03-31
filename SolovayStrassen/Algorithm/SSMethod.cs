using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolovayStrassen.Algorithm
{
    class SSMethod
    {
        public static async Task<bool> IsPrime(long number, int iteration, CancellationToken token = new CancellationToken())
        {
            await Task.Delay(TimeSpan.FromSeconds(3), token).ConfigureAwait(false);

            /** base case **/
            if (number == 0 || number == 1)
                return true;
            /** base case - 2 is prime **/
            if (number == 2)
                return true;
            /** an even number other than 2 is composite **/
            if (number % 2 == 0)
                return false;

            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {
                long r = Math.Abs(rand.Next());
                long a = r % (number - 1) + 1;
                long jacobian = (number + Jacobi(a, number)) % number;
                long mod = ModPow(a, (number - 1) / 2, number);
                if (jacobian == 0 || mod != jacobian)
                    return false;
            }
            return true;
        }

        private static long Jacobi(long a, long b)
        {
            if (b <= 0 || b % 2 == 0)
                return 0;
            long j = 1L;
            if (a < 0)
            {
                a = -a;
                if (b % 4 == 3)
                    j = -j;
            }
            while (a != 0)
            {
                while (a % 2 == 0)
                {
                    a /= 2;
                    if (b % 8 == 3 || b % 8 == 5)
                        j = -j;
                }

                long temp = a;
                a = b;
                b = temp;

                if (a % 4 == 3 && b % 4 == 3)
                    j = -j;
                a %= b;
            }
            if (b == 1)
                return j;

            return 0;
        }

        private static long ModPow(long a, long b, long c)
        {
            long res = 1;
            for (int i = 0; i < b; i++)
            {
                res *= a;
                res %= c;
            }
            return res % c;
        }

    }
}
