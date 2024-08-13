object liste = new List<int>();

if (liste is List<int>)
{
    
}
object obj = new List<int>();

if(obj.GetType() == typeof(List<int>))
{
    List<int> list1 = (List<int>)obj;
}

if(obj is List<int> lista)
{
    foreach (var item in lista)
    {
        
    }
}

List<int> list = [];

for (int i = 0; i < 10; i++)
    list.Add(i);

if (list is [1, 2, 3, .., _, int value])
{

}


if (list is [>10 and <20, 2 or 3, .., _])
{

}

// public static implicit operator Complex((double r, double i) value)
Complex a = (1, 2);

var c1 = new Complex();
var c2 = new Complex();
var sum = c1 + c2;



TemperaturaClassification Classify(int temperatura)
    => temperatura switch
    {
        >30 => TemperaturaClassification.Hot,
        <15 => TemperaturaClassification.Cold,
        _ => TemperaturaClassification.Ok
    };

GradeClassification ClassifyGrades(int math, int cience)
    => (math, cience) switch
    {
        (>90, _) or (_, >90) => GradeClassification.Good,
        (>70, >70) => GradeClassification.Good,
        (<50, _) and (_, <50) => GradeClassification.Bad,
        _ => GradeClassification.Meh
    };

int Count(IEnumerable<int> collection)
    => collection switch
    {
        ICollection<int> coll => coll.Count,
        null => 0,
        _ => collection.Count()
    };

bool CanDrive(Person person)
    => person switch
    {
        { IsFromDitactorFamily: true} => false,

        _ => false
    };


public enum GradeClassification
{
    Good,
    Bad,
    Meh
}

public enum TemperaturaClassification
{
    Hot,
    Ok,
    Cold
}

public class Person
{
    public string Name { get; set;}
    public int Age { get; set;}
    public bool IsFromDitactorFamily { get; set;}

}

public class Complex
{
    public double Real { get; set; }

    public double Imaginary { get; set; }

    public static implicit operator Complex((double r, double i) value)
    {
        return new Complex
        {
            Real = value.r,
            Imaginary = value.i
        };
    }

    public static bool operator ==(Complex c1, Complex c2)
        => c1.Real == c2.Real && c1.Imaginary == c2.Imaginary;

    public static bool operator !=(Complex c1, Complex c2)
        => !(c1 == c2);

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex
        {
            Real = c1.Real + c2.Real,
            Imaginary = c1.Imaginary + c2.Imaginary
        };
    }
}