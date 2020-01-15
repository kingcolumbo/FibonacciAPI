using System.Numerics;

namespace FibonacciApi.Business
{
    /// <summary>
    /// Contains business logic related to Fibonacci
    /// The solution uses the power of matrices and the exponentiation by squaring method to find fib values
    /// Initially tried solving using the golden ratio, but this lacked precision for larger values of 'n'
    /// BigInteger type is used to support large 'n' values 
    /// </summary>
    public class Fib
    {

        public Fib()
        {

        }

        public BigInteger FindFib(BigInteger n)
        {
            BigInteger result;

            FMatrix T = new FMatrix
            {
                R1C1 = 1,
                R1C2 = 1,
                R2C1 = 1,
                R2C2 = 0
            };
            //determine if the n is 1 or 0
            if (n == 1)
            {
                return 1;
            }
            if (n == 0)
            {
                return 0;
            }

            FMatrix rMatrix = RaiseToPower(T, n - 1);
            result = rMatrix.R1C1;
            return result;
        }

        /// <summary>
        /// Performs raising a matrix to a power
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private FMatrix RaiseToPower(FMatrix A, BigInteger n)
        {
            if (n == 1)
            {
                return A;
            }
            //decrement by 1 and multiply by itself if odd
            if (n % 2 == 1)
            {
                return MultiplyMatrix(A, RaiseToPower(A, n - 1));
            }
            //else raise power by 2 and multiply
            var B = RaiseToPower(A, n / 2);
            return MultiplyMatrix(B, B);
        }

        /// <summary>
        /// Multiplies 2 matrices together and returns result
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private FMatrix MultiplyMatrix(FMatrix A, FMatrix B)
        {
            FMatrix C = new FMatrix();
            C.R1C1 = A.R1C1 * B.R1C1 + A.R1C2 * B.R2C1;
            C.R1C2 = A.R1C1 * B.R1C2 + A.R1C2 * B.R2C2;
            C.R2C1 = A.R2C1 * B.R1C1 + A.R2C2 * B.R2C1;
            C.R2C2 = A.R2C1 * B.R1C2 + A.R2C2 * B.R2C2;
            return C;
        }

    }
}
