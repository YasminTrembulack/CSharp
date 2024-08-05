// // ----------------- MinhaClasse.CS -----------------

// // TimeProvider packge
// namespace MeuPacote;


// // posso fazer quantas classes eu quiser com o nome que eu quiser
// public class MinhaClasse
// {
    
// }


// // ----------------- PROGRAM.CS -----------------
// // public interface IEnumerator<T>
// // {
// //     bool MoveNext();
// //     T current { get; }
// // }

// // public interface IEnumerable<T>
// // {
// //     IEnumerator<T> GetEnumerator();
// // }




// // ITERADOR
// using System.Collections;

// printValues(new List<String>());
// printValues(new int[10]);

// void printValues<T>(IEnumerable<T> coll)
// {
//     var it = coll.GetEnumerator();
//     while (it.MoveNext())
//     {
//         var value = it.Current;
//         Console.WriteLine(value);
//     }
// }


// public class MyList<T> : ICollection<T>
// {
//     public int Count => throw new NotImplementedException();

//     public bool IsReadOnly => throw new NotImplementedException();

//     public void Add(T item)
//     {
//         throw new NotImplementedException();
//     }

//     public void Clear()
//     {
//         throw new NotImplementedException();
//     }

//     public bool Contains(T item)
//     {
//         throw new NotImplementedException();
//     }

//     public void CopyTo(T[] array, int arrayIndex)
//     {
//         throw new NotImplementedException();
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         throw new NotImplementedException();
//     }

//     public bool Remove(T item)
//     {
//         throw new NotImplementedException();
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//         => GetEnumerator();
// }