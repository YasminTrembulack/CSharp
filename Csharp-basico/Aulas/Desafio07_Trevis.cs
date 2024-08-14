// // using System;
// // using System.IO;
// // using System.Linq;
// // using System.Collections.Generic;

// IEnumerable<string> ReadLines()
// {
//     using var reader = new StreamReader("srag.csv");
//     var line = reader.ReadLine();
//     while (line is not null)
//     {
//         yield return line;
//         line = reader.ReadLine();
//     }
// }

// IEnumerable<Case> GetCases()
// {
//     var it = ReadLines().GetEnumerator();
//     it.MoveNext();
//     var header = it.Current.Split(';');

//     int classIndex = 0;
//     int evolutionIndex = 0;
//     int vacinatedIndex = 0;
    
//     for (int i = 0; i < header.Length; i++)
//     {
//         var column = header[i];
//         if (column == "\"CLASSI_FIN\"")
//             classIndex = i;
            
//         else if (column == "\"EVOLUCAO\"")
//             evolutionIndex = i;
        
//         else  if (column == "\"VACINA_COV\"")
//             vacinatedIndex = i;
//     }

//     while (it.MoveNext())
//     {
//         var data = it.Current.Split(';');
//         yield return new(
//             data[classIndex] == "5",
//             data[evolutionIndex] == "1",
//             data[evolutionIndex] == "2",
//             data[vacinatedIndex] == "1"
//         );
//     }
// }

// var covid =
//     from data in GetCases()
//     where data.IsCovid
//     select data;

// var livedVac =
//     (from data in covid
//     where data.Lived && data.Vacinated
//     select data).Count();

// var deadVac =
//     (from data in covid
//     where data.Dead && data.Vacinated
//     select data).Count();

// var livedUnv =
//     (from data in covid
//     where data.Lived && !data.Vacinated
//     select data).Count();

// var deadUnv =
//     (from data in covid
//     where data.Dead && !data.Vacinated
//     select data).Count();

// float vac = livedVac + deadVac;
// float unvac = livedUnv + deadUnv;

// Console.WriteLine(deadVac / vac);
// Console.WriteLine(deadUnv / unvac);

// public record Case(
//     bool IsCovid,
//     bool Lived,
//     bool Dead,
//     bool Vacinated
// );

// // List<int> list = [ 1, 2, 3, 4, 5, 6, 7, 17, 14, 22 ];
// // var query = 
// //     from item in list
// //     where item % 2 == 0
// //     group item by item % 10 into g
// //     where g.Count() > 1
// //     select g;

// // var query2 = list
// //     .Where(i => i % 2 == 0)
// //     .GroupBy(i => i % 10)
// //     .Where(g => g.Count() > 1);

// // public static class Enumerable
// // {
// //     public static R Aggregate<T, R>(
// //         this IEnumerable<T> coll, Func<T, R, R> acc, R seed)
// //     {
// //         foreach (var item in coll)
// //             seed = acc(item, seed);
// //         return seed;
// //     }

// //     public static bool Any<T>(
// //         this IEnumerable<T> coll, Func<T, bool> predicate)
// //     {
// //         foreach (var item in coll)
// //             if (predicate(item))
// //                 return true;
        
// //         return false;
// //     }
// //     public static T MaxBy<T>(
// //         this IEnumerable<T> coll, Func<T, double> selector)
// //     {
// //         T max = coll.FirstOrDefault();
// //         var maxValue = selector(max);

// //         foreach (var current in coll)
// //         {
// //             var newValue = selector(current);
// //             if (newValue > maxValue)
// //             {
// //                 maxValue = newValue;
// //                 max = current;
// //             }
// //         }

// //         return max;
// //     }

// //     public static IEnumerable<T> SkipWhile<T>(
// //         this IEnumerable<T> coll, Func<T, bool> predicate)
// //     {
// //         var it = coll.GetEnumerator();
// //         while (it.MoveNext() && predicate(it.Current));
// //         do yield return it.Current; while (it.MoveNext());
// //     }
    
// //     public static IEnumerable<T> TakeWhile<T>(
// //         this IEnumerable<T> coll, Func<T, bool> predicate)
// //     {
// //         foreach (var item in coll)
// //         {
// //             if (!predicate(item))
// //                 break;
            
// //             yield return item;
// //         }
// //     }



// //     public static IEnumerable<R> Select<T, R>(
// //         this IEnumerable<T> coll,
// //         Func<T, R> mapper
// //     )
// //     {
// //         foreach (var item in coll)
// //             yield return mapper(item);
// //     }

// //     public static IEnumerable<T> Where<T>(
// //         this IEnumerable<T> coll,
// //         Func<T, bool> filter
// //     ) {
// //         foreach (var item in coll)
// //         {
// //             if (filter(item))
// //                 yield return item;
// //         }
// //     }
// // } 

// // public static class Enumerable
// // {
// //     public static IEnumerable<T[]> Chunk<T>(
// //         this IEnumerable<T> coll,
// //         int size
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static IEnumerable<(T, R)> Zip<T,R>(
// //         this IEnumerable<T> coll,
// //         IEnumerable<R> other
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static T FirstOrDefault<T>(
// //         this IEnumerable<T> coll
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static bool Empty<T>(
// //         this IEnumerable<T> coll
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static IEnumerable<T> Append<T>(
// //         this IEnumerable<T> coll, T item
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static IEnumerable<T> Prepend<T>(
// //         this IEnumerable<T> coll, T item
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static T[] ToArray<T>(
// //         this IEnumerable<T> coll
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static int Count<T>(
// //         this IEnumerable<T> coll
// //     )
// //     {
// //         throw new NotImplementedException();
// //     }

// //     public static IEnumerable<T> Skip<T>(
// //         this IEnumerable<T> coll, int count
// //     )
// //     {
// //         var it = coll.GetEnumerator();
// //         for (int i = 0; i < count && it.MoveNext(); i++);
        
// //         while (it.MoveNext())
// //             yield return it.Current;
// //     }

// //     public static IEnumerable<T> Take<T>(
// //         this IEnumerable<T> coll, int count)
// //     {
// //         var it = coll.GetEnumerator();
// //         for (int i = 0; i < count && it.MoveNext(); i++)
// //             yield return it.Current;
// //     }
// // }

// // public class MyList<T> : Icoll<T>
// // {
// //     const int nodeSize = 32;

// //     MyNode head = null;
// //     MyNode tail = null;

// //     int count = 0;
// //     int currentPos = nodeSize;
// //     public int Count => count;
// //     public bool IsReadOnly => false;

// //     public T this[int index]
// //     {
// //         get
// //         {
// //             var crr = head;
// //             while (index > nodeSize)
// //             {
// //                 index -= nodeSize;
// //                 crr = crr.Next;
// //             }
// //             return crr.Data[index];
// //         }
// //         set
// //         {
// //             var crr = head;
// //             while (index > nodeSize)
// //             {
// //                 index -= nodeSize;
// //                 crr = crr.Next;
// //             }
// //             crr.Data[index] = value;
// //         }
// //     }

// //     public void Add(T item)
// //     {
// //         count++;
// //         if (currentPos == nodeSize)
// //             AddNode();
        
// //         tail.Data[currentPos++] = item;
// //     }

// //     public void Clear()
// //         => head = tail = null;

// //     public bool Contains(T item)
// //     {
// //         var crr = head;
// //         while (crr != tail)
// //         {
// //             if (Contains(crr, item))
// //                 return true;
// //             crr = crr.Next;
// //         }
        
// //         return Contains(tail, item, currentPos);
// //     }

// //     public void CopyTo(T[] array, int arrayIndex)
// //     {
// //         foreach (var item in this)
// //             array[arrayIndex++] = item;
// //     }

// //     public IEnumerator<T> GetEnumerator()
// //     {
// //         var crr = head;
// //         while (crr != tail)
// //         {
// //             foreach (var item in crr.Data)
// //                 yield return item;
// //             crr = crr.Next;
// //         }
// //         for (int i = 0; i < currentPos; i++)
// //             yield return tail.Data[i];
// //     }

// //     public bool Remove(T item)
// //     {
// //         var crr = head;
// //         while (crr != tail)
// //         {
// //             if (Remove(crr, item))
// //                 return true;
// //             crr = crr.Next;
// //         }
// //         return false;
// //     }

// //     IEnumerator IEnumerable.GetEnumerator()
// //         => GetEnumerator();

// //     void Remove(MyNode node, int index)
// //     {
// //         if (!TryPop(out T value))
// //             return;
        
// //         node.Data[index] = value;
// //     }

// //     bool Remove(MyNode node, T item)
// //     {
// //         for (int i = 0; i < node.Data.Length; i++)
// //         {
// //             var value = node.Data[i];
// //             if (item is null && value is null)
// //             {
// //                 Remove(node, i);
// //                 return true;
// //             }
            
// //             if (item is null)
// //                 continue;

// //             if (item.Equals(value))
// //             {
// //                 Remove(node, i);
// //                 return true;
// //             }
// //         }

// //         return false;
// //     }

// //     static bool Contains(MyNode node, T item, int size = -1)
// //     {
// //         if (size == -1)
// //             size = node.Data.Length;
        
// //         for (int i = 0; i < size; i++)
// //         {
// //             var value = node.Data[i];
// //             if (item is null && value is null)
// //                 return true;
            
// //             if (item is null)
// //                 continue;

// //             if (item.Equals(value))
// //                 return true;
// //         }

// //         return false;
// //     }

// //     bool TryPop(out T value)
// //     {
// //         value = default;
// //         if (tail is null)
// //             return false;
        
// //         value = tail.Data[currentPos];
// //         tail.Data[currentPos] = default;

// //         count--;
// //         currentPos--;
// //         if (currentPos == 0)
// //             RemoveNode();
        
// //         return true;
// //     }

// //     void RemoveNode()
// //     {
// //         if (tail is null)
// //             return;
        
// //         tail = tail.Previous;
// //         tail.Next = null;
// //         count -= currentPos;
// //         currentPos = nodeSize;
// //     }

// //     void AddNode()
// //     {
// //         var newNode = new MyNode
// //         {
// //             Data = new T[nodeSize],
// //             Next = null,
// //             Previous = tail
// //         };
// //         if (tail is not null)
// //             tail.Next = newNode;
        
// //         tail = newNode;
// //         head ??= newNode;
// //         currentPos = 0;
// //     }

// //     System.colls.IEnumerator System.colls.IEnumerable.GetEnumerator()
// //     {
// //         throw new NotImplementedException();
// //     }

// //     class MyNode
// //     {
// //         public T[] Data { get; set; }
// //         public MyNode Next { get; set; }
// //         public MyNode Previous { get; set; }
// //     }
    
// //     public class MyIterator(MyList<T> list) : IEnumerator<T>
// //     {
// //         int index = -1;
// //         MyNode node = list.head;
// //         public T Current => node.Data[index];

// //         object IEnumerator.Current => Current;

// //         public void Dispose() { }

// //         public bool MoveNext()
// //         {
// //             index++;
// //             if (index == nodeSize)
// //             {
// //                 index = 0;
// //                 node = node.Next;
// //             }

// //             if (node is null)
// //                 return false;

// //             return node != list.tail || index < list.currentPos;
// //         }

// //         public void Reset()
// //         {
// //             index = -1;
// //             node = list.tail;
// //         }
// //     }
// // }