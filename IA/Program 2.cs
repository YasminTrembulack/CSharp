// void MostrarNumeroComplicadoAsync()
// {
//     var estado = calcularNumeroComplicadoAsync();
//     Thread thread = new Thread(() =>
//     {
//         while (!estado.EstaCompleto)
//             Thread.Yield();
//         Console.WriteLine(estado.resultado);
//     });
//     thread.Start();
// }


// EstadoAssincrono<long> calcularNumeroComplicadoAsync()
// {
//     EstadoAssincrono<long> estado = new EstadoAssincrono<long>();
//     var thread = new Thread(() =>
//     {
//         var result = calcularNumeroComplicado();
//         estado.resultado = result;
//         estado.EstaCompleto = true;
//     });
//     thread.Start();
//     return estado;
// }


// public class EstadoAssincrono<T>
// {
//     public T resultado { get; set; }
//     public bool EstaCompleto { get; set; }
// }