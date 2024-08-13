using System.Data.SqlTypes;

// Random rand = new Random();

// byte[] array = new byte[10];
// rand.NextBytes(array);

// foreach (var item in array)
// {
//     Console.WriteLine(item);
// }












// byte[] array1 = { 0, 1, 2, 3, 10 };
// byte[] array2 = { 0, 0, 4, 5, 255 };

// BigInt num1 = new BigInt(array1);
// BigInt num2 = new BigInt(array2);

// BigInt sum = num1 + num2;

// Console.WriteLine("num1: " + num1); // Esperado: 321
// Console.WriteLine("num2: " + num2); // Esperado: 654
// Console.WriteLine("Sum: " + sum); // Esperado: 975

// Console.WriteLine("num1 > num2: " + (num1 > num2)); // Esperado: False
// Console.WriteLine("num1 < num2: " + (num1 < num2)); // Esperado: True
// Console.WriteLine("num1 == num2: " + (num1 == num2)); // Esperado: False
// Console.WriteLine("num1 != num2: " + (num1 != num2)); // Esperado: True

byte[] array1 = [1];                       // 1 byte
byte[] array2 = [1, 2];                    // 2 bytes
byte[] array3 = [1, 2, 3];                 // 3 bytes
byte[] array4 = [1, 2, 3, 4];              // 4 bytes
byte[] array5 = [1, 2, 3, 4, 5];           // 5 bytes
byte[] array6 = [1, 2, 3, 4, 5, 6];        // 6 bytes
byte[] array7 = [1, 2, 3, 4, 5, 6, 7];     // 7 bytes
byte[] array8 = [1, 2, 3, 4, 5, 6, 7, 8];  // 8 bytes
byte[] array9 = [1, 2, 3, 4, 5, 6, 7, 8, 9]; // 9 bytes
byte[] array10 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]; // 10 bytes
byte[] array11 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]; // 11 bytes
byte[] array12 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]; // 12 bytes
byte[] array13 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]; // 13 bytes
byte[] array14 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]; // 14 bytes
byte[] array15 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]; // 15 bytes
byte[] array16 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]; // 16 bytes
byte[] array17 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]; // 17 bytes
byte[] array18 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]; // 18 bytes
byte[] array19 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]; // 19 bytes
byte[] array20 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]; // 20 bytes

// Criando objetos BigInt a partir dos arrays
BigInt num1 = new(array1);
BigInt num2 = new(array2);
BigInt num3 = new(array3);
BigInt num4 = new(array4);
BigInt num5 = new(array5);
BigInt num6 = new(array6);
BigInt num7 = new(array7);
BigInt num8 = new(array8);
BigInt num9 = new(array9);
BigInt num10 = new(array10);
BigInt num11 = new(array11);
BigInt num12 = new(array12);
BigInt num13 = new(array13);
BigInt num14 = new(array14);
BigInt num15 = new(array15);
BigInt num16 = new(array16);
BigInt num17 = new(array17);
BigInt num18 = new(array18);
BigInt num19 = new(array19);
BigInt num20 = new(array20);

// Criando a lista com 20 elementos
BigInt[] list = [num12, num4, num17, num3, num13, num10, num1, num16, num9, num20, num7, num5, num11, num19, num18, num2, num6, num8, num14, num15];

foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine("----------");

BigInt[] sla = Sort(list);
foreach (var item in sla)
{
    Console.WriteLine(item);
}


BigInt[] Sort(BigInt[] array)
{
    int length = array.Length;

    int startIndex = 0;
    int middleIndex = length / 2 ;
    int endIndex = length;

    var leftSide = array[startIndex..middleIndex];
    var rightSide = array[middleIndex..endIndex];

    
    // Console.WriteLine("----AAAA----");
    // Console.WriteLine("----LEFT----");
    // foreach (var item in leftSide)
    // {
    //     Console.WriteLine(item);
    // }
    // Console.WriteLine("-----RIGHT-------");
    // foreach (var item in rightSide)
    // {
    //     Console.WriteLine(item);
    // }


    if(leftSide.Length > 3)
    {
        leftSide = Sort(leftSide);
    }
    else{
        leftSide = Order(leftSide);
    }

     if(rightSide.Length > 3)
    {
        rightSide = Sort(rightSide);
    }
    else{
        rightSide = Order(rightSide);
    }
    

    return [..leftSide, ..rightSide];
}

BigInt[] Order(BigInt[] array)
{
    int elements = array.Length;

    int leftIndex = 0;
    int rightIndex = elements / 2;

    BigInt[] helper = new BigInt[elements];

    for (int i = 0; i < elements; i++)
    {
        if(rightIndex > elements - 1)
        {
            helper[i] = array[leftIndex];
            rightIndex++;
            continue;
        }
        if(leftIndex == elements / 2)
        {
            helper[i] = array[rightIndex];
            leftIndex++;
            continue;
        }

        if(array[leftIndex] < array[rightIndex])
        {
            helper[i] = array[leftIndex];
            leftIndex++;
        }
        else
        {
            helper[i] = array[rightIndex];
            rightIndex++;
        }
    }
    return helper;
}

// List<BigInt> getRandom(List<BigInt> array)
// {

// }

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

        for (int i = 0 ; i < maxLength ; i++)
        {
            int aValue = i < a._array.Length ? a._array[i] : 0;
            int bValue = i < b._array.Length ? b._array[i] : 0;

            int sum = aValue + bValue + carry;
            carry = sum / 256; 
            result.Add((byte)(sum % 256));
           
        }
        if (carry > 0)
        {
            result.Add((byte) carry);
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

    internal int CompareTo(BigInt bigInt)
    {
        throw new NotImplementedException();
    }
}