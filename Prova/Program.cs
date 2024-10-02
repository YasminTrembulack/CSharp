// 1) 

using System.Reflection;
using System.Text;

IEnumerable<int> list01 = [1, 2, 3];
IEnumerable<int> list02 = [3, 2, 1];
var result = list01.DoSomething(list02, (a, b) => a > b);
foreach (var item in result)
{
    System.Console.WriteLine(item);
}


// 2)

// RESPOSTA: 
//Para mim parece que você esta utilizando o padrão Builder pois, você faz um interface Node e faz varias inplementações dela com seus métodos, possibilitando, que o atributo main do NodeBuilder recebar qualquer um dos tres, mudando apenas os atributos para a montagem do Node. 

// utilizando o padrão Decorator pois, você faz um interface comum(Node) e faz varias inplementações dela com seus métodos, logo em seguida o NodeBuilder tem um atributo para referenciar um Node.

// Strategy pois você mantem uma referencia da sua estratégia no NodeBuilder e a cria um interface que é herdada por todas suas implementações dela (ActionNode, FilterNode, ParentNode) com diferentes variações, alem disso você pode definir vair ser o seu builder, ou a action do seu NodeBuilder.

// Utilizando singleton no App


// 3) 


MyConsole.AddComponent(new LoginForm(40)
                            .AddLabelInput("Name","Digite seu nome")
                            .AddLabelInput("Senha","Digite sua senha"));
MyConsole.Print();



// 4) 

Activator activator = new();
object inst = activator.Create("QuestionFour");
activator.Call("PrintName", inst, ["Yasmin"]);
activator.CreateAndCall("QuestionFour", "PrintHello", []);

public class QuestionFour
{
    public void PrintName(string name)
    {
        System.Console.WriteLine($"Seu nome é: {name}");
    }
    public void PrintHello()
    {
        System.Console.WriteLine("Olaaa");
    }
}

public class Activator 
{
    public object Create(string nameClass)
    {
        var arquivo = Assembly.GetExecutingAssembly();
        var instance = arquivo.CreateInstance(nameClass) 
            ?? throw new Exception("Classe não encontrada.");
        return instance;
    }
    public object? Call(string name, object obj , object[] parans)
    {
        Type myType = obj.GetType();
        MethodInfo[] myArrayMethodInfo = myType.GetMethods();

        MethodInfo? method = myArrayMethodInfo.FirstOrDefault( mt => mt.Name == name) 
            ?? throw new Exception("Metodo não encontrad0.");

        return method.Invoke(obj, parans);
    }
    public object? CreateAndCall(string nameClass, string nameMethod , object[] parans)
    {
        var arquivo = Assembly.GetExecutingAssembly();
        var instance = arquivo.CreateInstance(nameClass) 
            ?? throw new Exception("Classe não encontrada.");
        
        Type myType = instance.GetType();
        MethodInfo[] myArrayMethodInfo = myType.GetMethods();

        MethodInfo? method = myArrayMethodInfo.FirstOrDefault( mt => mt.Name == nameMethod) 
            ?? throw new Exception("Metodo não encontrad0.");

        return method.Invoke(instance, parans);
    }
}



// --------------------------------- QUESTAO 01 ---------------------------------
public static class QuestionOne
{
    public static IEnumerable<T> DoSomething<T>(this IEnumerable<T> list01, IEnumerable<T> list02, Func<T, T, bool> func )
    {
        List<T> result = [];

        for (int i = 0; i < list01.Count(); i++)
        {
            T item01 = list01.ElementAt(i);
            T item02 = list02.ElementAt(i);
            if (func(item01, item02))
                result.Add(item01);
            else
                result.Add(item02);
        }
        return result;
    }
}


// --------------------------------- QUESTAO 03 ---------------------------------

public abstract class IPrint
{
    public abstract void Print();
}

public class PrintLine(int size, string caracter) : IPrint
{
    private int Size = size;
    private string Caracter = caracter;

    public override void Print()
    {
        StringBuilder line = new();
        for (int i = 0; i < Size; i++)
        {
           line.Append(Caracter);
        }
        System.Console.WriteLine(line);
    }
}
public class PrintLabel(string text) : IPrint
{
    private string Text = text;
    public override void Print()
    {
        System.Console.WriteLine(Text.ToUpperInvariant()+":");
    }
}
public class PrintButton(string text) : IPrint
{
    private string Text = text;
    public override void Print()
    {
        System.Console.WriteLine(Text.ToUpperInvariant()+":");
    }
}

public class PrintInput(int size, string placeholder = "") : IPrint
{
    private int Size = size;
    private string Placeholder = placeholder;
    public override void Print()
    {
        StringBuilder lineT = new();
        StringBuilder lineM = new();
        StringBuilder lineB = new();
        lineT.Append("┌");
        lineB.Append("└");
        for (int i = 0; i < Size; i++)
        {
           lineT.Append("─");
           lineB.Append("─");
        }
        lineT.Append("┐");
        lineB.Append("┘");
        lineM.Append("│  ");
        lineM.Append(Placeholder);
        for (int i = 0; i < Size-4-Placeholder.Length; i++)
        {
            lineM.Append(" ");
        }
        lineM.Append("  │");
        System.Console.WriteLine(lineT);
        System.Console.WriteLine(lineM);
        System.Console.WriteLine(lineB);
    }
}

public abstract class IComponent 
{
    public abstract void Build();
    
}

public class LoginForm(int size) : IComponent
{
    private int Size = size;
    private List<IPrint> Prints { get; set; } = [];
    public LoginForm AddLabelInput(string textLabel, string textPlace = "")
    {
        Prints.Add(new PrintLabel(textLabel));
        Prints.Add(new PrintInput(Size, textPlace));
        return this;
    }
    public LoginForm AddLabel(string textLabel)
    {
        Prints.Add(new PrintLabel(textLabel));
        return this;
    }
    public LoginForm AddInput(string textPlace = "")
    {
        Prints.Add(new PrintInput(Size, textPlace));
        return this;
    }
    public override void Build()
    {
        foreach (var item in Prints)
        {
            item.Print();
        }
    }
}

public class MyConsole
{   
    private static List<IComponent> Components { get; set; } = [];

    public static void AddComponent(IComponent component){
        Components.Add(component);
    }

    public static void Print()
    {
        foreach (var item in Components)
        {
            item.Build();
        }
    }
}