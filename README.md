criar projeto
dotnet new console

tirou isso do C#.csproj
    <Nullable>enable</Nullable>

criar gitgnore
dotnet new gitignore

rodar o projeto
dotnet run


# Aula 01

```
// falo que estou usando esse pacote 
using MeuPacote;

// quando escrevo isso meu pacote fica visivel para todos os arquivos
// global using MeuPacote;

MinhaClasse minhaClasse = new MinhaClasse();

Console.WriteLine("Hello, World!");
Console.BackgroundColor = ConsoleColor.Blue; // Alterar a cor do terminal
// Console.Beep(200, 200); // Barulho 


var tupla = (1, 2);
tupla.Item1 = 2;

public record A(string Nome);

public struct DateTimeA
{
    private long secs;
    public DateTimeA(){}
    public long TotalSecs(){
        return secs;
    }
}

Pessoa pessoa = new Pessoa("yasmin");
pessoa.Nome += "aaaa";

public class Pessoa
{
    public Pessoa(string  nome){
        Nome = nome;
    }
    public string  Nome { get; set; } 
    public int NameSize => Nome.Length;

    public override string ToString()
        => Nome;
}

var listt = new List();
var value = listt[1];

public class List
{
    int[] array = new int[10];

    public int this[int index]{
        get => array[index];
        set => array[index] = value;
    }
}

MyClass<int> obj = new MyClass<int>();
int val = obj.First;

public class MyClass<T>()
    // where T: class
    // where T: class, new()
{
    // T variavel = null;
    // T variavel = new T();
    T[] array = new T[10];

    public T First => array[0];
}

List<int> listint = [0, 1, 2];
int[] array = [..listint, 3, 4];
listint.Add(0);
listint.Add(1);
listint.Add(2);
listint.Add(3);
var data = array[2..3];
var ultimo = array[^1];
```
