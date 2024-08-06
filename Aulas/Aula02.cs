// // using dotnet_lesson.CustomCollections;

// // MyList<Int32> muchosNumbers = [];

// // for (int i = 0; i < 320; i++)
// // {
// //     muchosNumbers.Add(i);
// // }

// // Console.WriteLine(muchosNumbers.Count);
// // Console.WriteLine(muchosNumbers);

// // int[] numsToRemove = [ ..Enumerable.Range(50, 50) ];
// // foreach (int a in numsToRemove)
// //     muchosNumbers[a] = 999;

// // var enumerator = muchosNumbers.GetEnumerator();

// // while (enumerator.MoveNext())
// // {
// //     Console.WriteLine(enumerator.Current);
// // }


// List<int> list_1 = [0, 1, 2, 3, 4, 5, 6, 7, 8];


// var take_query = list_1.Take(3);
// Console.WriteLine("-------- Take(3) --------");
// foreach (var item in take_query)
//     Console.WriteLine(item);

// var skip_query = list_1.Skip(3);
// Console.WriteLine("-------- Skip(3) --------");
// foreach (var item in skip_query)
//     Console.WriteLine(item);

// Console.WriteLine("-------- Count() --------");
// Console.WriteLine(list_1.Count());

// var to_array = list_1.toArray();
// Console.WriteLine("-------- toArray() --------");
// foreach (var item in to_array)
//     Console.WriteLine(item);

// var append = list_1.Append(99);
// Console.WriteLine("-------- Append() --------");
// foreach (var item in append)
//     Console.WriteLine(item);

// var prepend = list_1.Prepend(99);
// Console.WriteLine("-------- Prepend() --------");
// foreach (var item in prepend)
//     Console.WriteLine(item);

// List<int> list_2 = [];
// Console.WriteLine("-------- Empty() --------");
// Console.WriteLine(list_1.Empty());
// Console.WriteLine(list_2.Empty());

// Console.WriteLine("-------- FirstOrDefault() --------");
// Console.WriteLine(list_1.FirstOrDefault());

// var chunk = list_1.Chunk(3);
// Console.WriteLine("-------- Chunk() --------");
// foreach (var item in chunk)
//     foreach (var i in item)
//         Console.WriteLine(i);


// List<int> list_3 = [65, 34, 234, 434];
// var zip = list_1.Zip(list_3);
// Console.WriteLine("-------- Zip() --------");
// foreach (var item in zip)
//     Console.WriteLine(item);
    

// public static class Enumerable
// {
//     public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count){
//         var it = collection.GetEnumerator();
//         for (int i = 0; i < count && it.MoveNext(); i++)
//             yield return it.Current;
//     }

//     public static IEnumerable<T> Skip<T>(this IEnumerable<T> collection, int count){
//         var it = collection.GetEnumerator();
//         for (int i = 0; it.MoveNext(); i++){
//             if (i < count)
//                 continue;
//             yield return it.Current;
//         }  
//     }
//     public static int Count<T>(this IEnumerable<T> collection){
//         var it = collection.GetEnumerator();
//         var count = 0;
//         for (int i = 0; it.MoveNext(); i++)
//             count++;
//         return count;
//     }
//     public static T[] toArray<T>(this IEnumerable<T> collection){
//         var it = collection.GetEnumerator();
//         T[] array = new T[collection.Count()];
//         for (int i = 0; it.MoveNext(); i++)
//             array[i] = it.Current;
//         return array;
//     }
//     public static IEnumerable<T> Append<T>(this IEnumerable<T> collection, T item){
//         var it = collection.GetEnumerator();
//         for (int i = 0; it.MoveNext(); i++)
//             yield return it.Current;
//         yield return item;
//     }
//     public static IEnumerable<T> Prepend<T>(this IEnumerable<T> collection, T item){
//         var it = collection.GetEnumerator();
//         yield return item;
//         for (int i = 1; it.MoveNext(); i++)
//             yield return it.Current;
//     }
//     public static bool Empty<T>(this IEnumerable<T> collection){
//         var it = collection.GetEnumerator();
//         if(it.MoveNext())
//             return false;
//         return true;
//     }
//     public static T FirstOrDefault<T>(this IEnumerable<T> collection){
//         var it = collection.GetEnumerator();
//         if(it.MoveNext())
//             return it.Current;
//         return default;
//     }
//     public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> collection, int size){
//         var it = collection.GetEnumerator();
//         var qtd_chunk = collection.Count() % size != 0 ? collection.Count()/size + 1 : collection.Count()/size;
//         for (int i = 0; i < qtd_chunk; i++){
//             T[] array = new T[size];
//             for (int j = 0; j < size; j++)
//             {
//                 it.MoveNext();
//                 array[j]= it.Current;
//             }
//             yield return array;
//         }
//     }
//     public static IEnumerable<(T, R)> Zip<T, R>(this IEnumerable<T> collection_1, IEnumerable<R> collection_2){
//         var col_1 = collection_1.GetEnumerator();
//         var col_2 = collection_2.GetEnumerator();
//         for (int i = 0; col_1.MoveNext() && col_2.MoveNext(); i++)
//         {
//             (T, R) array = new(col_1.Current, col_2.Current);
//             yield return array;
//         }
//     }
// }