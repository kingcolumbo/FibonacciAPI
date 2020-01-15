using System.Numerics;

namespace FibonacciApi.Business
{
    /// <summary>
    /// Model used to create matrices with type BigInteger for large nth values
    /// </summary>
    public class FMatrix
    {
        public BigInteger R1C1 { get; set; }
        public BigInteger R1C2 { get; set; }
        public BigInteger R2C1 { get; set; }
        public BigInteger R2C2 { get; set; }
    }
}
