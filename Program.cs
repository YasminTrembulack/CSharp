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
}





