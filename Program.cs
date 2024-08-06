// PROGRAMAÇÃO FUNCIONAL 
// public delegate void Func(string s);
// criando um tipo chamado func 

Action<string> print = Console.WriteLine;
// posso fazer minhas propias funções e colocar em um variavel ou colocar alguma existente
print("Hello world!");



int minhaFuncao(int a, int b)
{
    return a + b;
};
Func<int, int, int> sum = minhaFuncao;
var result_soma = sum(5, 2);
print(result_soma.ToString());



Func<int, int, int> sub = (a, b) => a - b;
var result_sub = sub(5, 2);
print(result_sub.ToString());



var soma = (int[] array) =>
{
    int total = 0;
    foreach (var value in array)
        total += value;
    return total;     
};
var result_arr_soma = soma([1,2,3,4,5,6,7,8]);
print(result_arr_soma.ToString());



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