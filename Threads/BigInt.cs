namespace BigIntImplementY
{
    public class BigInt
    {
        public byte[] _array { get; set; }

        public BigInt(byte[] array)
        {
            _array = array;
        }

        public static BigInt operator +(BigInt a, BigInt b)
        {
            var bigger = a._array.Length < b._array.Length ? b : a;

            int maxLength = bigger._array.Length;
            List<byte> result = new List<byte>(maxLength + 1);
            int carry = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int aValue = i < a._array.Length ? a._array[i] : 0;
                int bValue = i < b._array.Length ? b._array[i] : 0;

                int sum = aValue + bValue + carry;
                carry = sum / 256;
                result.Add((byte)(sum % 256));

            }
            if (carry > 0)
            {
                result.Add((byte)carry);
            }
            return new BigInt(result.ToArray());
        }

        public static bool operator >(BigInt a, BigInt b)
        {
            if (a._array.Length > b._array.Length)
                return true;

            if (a._array.Length < b._array.Length)
                return false;

            for (int i = a._array.Length - 1; i >= 0; i--)
            {
                if (a._array[i] > b._array[i])
                    return true;
                if (a._array[i] < b._array[i])
                    return false;
            }
            return false;
        }

        public static bool operator <(BigInt a, BigInt b)
            => !(a > b) && !(a == b);


        public static bool operator ==(BigInt a, BigInt b)
        {

            if (a._array.Length != b._array.Length)
                return false;

            for (int i = 0; i < a._array.Length; i++)
            {
                if (a._array[i] != b._array[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(BigInt a, BigInt b)
            => !(a == b);

        public override string ToString()
        {
            return string.Join(" ", _array.Select(b => b.ToString()));
        }


        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }


}