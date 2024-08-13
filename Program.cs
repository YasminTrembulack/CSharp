// PROGRAMAÇÃO FUNCIONAL 
// public delegate void Func(string s);
// criando um tipo chamado func 

Action<string> print = Console.WriteLine;
// posso fazer minhas propias funções e colocar em um variavel ou colocar alguma existente
print("Hello world!");


Console.WriteLine("-----------------------");
int minhaFuncao(int a, int b)
{
    return a + b;
};
Func<int, int, int> sum = minhaFuncao;
var result_soma = sum(5, 2);
print(result_soma.ToString());


Console.WriteLine("-----------------------");
Func<int, int, int> sub = (a, b) => a - b;
var result_sub = sub(5, 2);
print(result_sub.ToString());


Console.WriteLine("-----------------------");
var soma = (int[] array) =>
{
    int total = 0;
    foreach (var value in array)
        total += value;
    return total;     
};
var result_arr_soma = soma([1,2,3,4,5,6,7,8]);
print(result_arr_soma.ToString());


Console.WriteLine("-----------------------");

var chamaNVezes = (Action Func, int n) =>
{
    for (int i = 0; i < n; i++)
        Func();
};
chamaNVezes( () => Console.WriteLine("oi"), 100 );



Func<int, Func<int>> func = (n) =>
{
    return () => n + 5; 
};
// tem como parametro um int e me retorna uma função com retorno int


Console.WriteLine("-----------------------");
// da um coleção de dados e o tamanho de cada pagina
Func<int[], int, Func<int, int[]>> paginator = (dados, tamanho) =>
{
    return (pagina) => {
        int[] paginaDados = new int[tamanho];
        Array.Copy(
            dados, tamanho * pagina,
            paginaDados, 0,
            tamanho
        );
        return paginaDados;
    };
};
var paginas = paginator([1, 2, 3, 4, 5, 6], 2);
var pagina02 = paginas(2);
foreach (var item in pagina02)
    Console.WriteLine(item);


Console.WriteLine("-----------------------");
Func<Func<int>> closure = () =>
{
    int count = 0;
    return () => {
        count++;
        return count;
    };
    // return () => ++count;
};
var contador = closure();
Console.WriteLine(contador());
Console.WriteLine(contador());
Console.WriteLine(contador());
Console.WriteLine(contador());

//Ta errado
// Func<Object, (Func<Object> data, Action<dynamic> setData)> useSatate = (object data) =>
// {
//     var value = data;
//     return () => value, (object newValue) => value = newValue;

// }

Console.WriteLine("-----------------------");
List<int> listaMinha = [1, 2, 3, 4, 5, 6, 7, 8];
var pares = listaMinha.Where((element) => element % 2 == 0);
foreach (var item in pares)
    Console.WriteLine(item);



Console.WriteLine("-----------------------");
var pares_maior = listaMinha
            .Where((element) => element % 2 == 0)
            .Where((x) => x > 2);
foreach (var item in pares_maior)
    Console.WriteLine(item);



Console.WriteLine("-----------------------");
var select = listaMinha.Select((x) => x * 2);
foreach (var item in select)
    Console.WriteLine(item);



Console.WriteLine("-----------------------");
List<string> list_str = ["1", "2", "3", "4", "5", "6", "7", "8"];
var list_int = list_str.Select(int.Parse);
foreach (var item in list_int)
    Console.WriteLine(item);



Console.WriteLine("----------- Aula 04 ------------");
var take_while = listaMinha.TakeWhile((x) => x < 5);
foreach (var item in take_while)
    Console.WriteLine(item);



Console.WriteLine("-----------------------");
var skip_while = listaMinha.SkipWhile((x) => x < 5);
foreach (var item in skip_while)
    Console.WriteLine(item);



Console.WriteLine("-----------------------");
Pessoa yasmin = new("yasmin", 18);
Pessoa eduardo = new("eduardo", 19);
Pessoa julia = new("julia", 16);

Pessoa[] pessoas = [yasmin, eduardo, julia];

var maior_idade = pessoas.MaxBy((p) => p.Idade);
Console.WriteLine(maior_idade);



Console.WriteLine("-----------------------");
var any_false = listaMinha.Any((x) => x % 13 == 0);
Console.WriteLine(any_false);
var any_true = listaMinha.Any((x) => x % 7 == 0);
Console.WriteLine(any_true);



Console.WriteLine("-----------------------");
var aggregate = listaMinha.Aggregate((x, y) => x + y, 10);
Console.WriteLine(aggregate);

public class Pessoa{

    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
    public override string ToString()
    {
        return "Nome: " + Nome + " Idade: " + Idade;
    }
}



public static class Enumerable
{
    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> collection,
        Func<T, bool> filter
    )
    {
        foreach (var item in collection)
            if (filter(item))
                yield return item;

    }
    public static IEnumerable<R> Select<T, R>(
        this IEnumerable<T> collection,
        Func<T, R> mapper
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));

        var it = collection.GetEnumerator();
        while(it.MoveNext())
            yield return mapper(it.Current);
    }
    public static IEnumerable<T> TakeWhile<T>(
        this IEnumerable<T> collection,
        Func<T, bool> predicate
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        foreach (var item in collection)
        {
            if(!predicate(item))
                break;
            yield return item;
        }
    }
    public static IEnumerable<T> SkipWhile<T>(
        this IEnumerable<T> collection,
        Func<T, bool> predicate
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        var canReturn = false;
        foreach (var item in collection){
            if(!predicate(item))
                canReturn = true;
            if(canReturn)
                yield return item;
        }
    }
    public static T MaxBy<T>(
        this IEnumerable<T> collection,
        Func<T, double> selector
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        var it = collection.GetEnumerator();
        it.MoveNext();
        T max = it.Current;
        while(it.MoveNext())
            if(selector(it.Current) > selector(max))
                max = it.Current;
        return max;
    }
    public static bool Any<T>(
        this IEnumerable<T> collection,
        Func<T, bool> predicate
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        var it = collection.GetEnumerator();
        while(it.MoveNext())
            if(predicate(it.Current))
                return true;
        return false;
    }
    public static R Aggregate<T, R>(
        this IEnumerable<T> collection,
        Func<T, R, R> acc,
        R seed
    )
    {   
        ArgumentNullException.ThrowIfNull(collection, nameof(collection));

        var it = collection.GetEnumerator();
        while(it.MoveNext())
            seed = acc(it.Current, seed);
        return seed;
    }
}


