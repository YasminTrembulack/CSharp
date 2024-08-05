using dotnet_lesson.CustomCollections;

MyList<Int32> muchosNumbers = [];

for (int i = 0; i < 320; i++)
{
    muchosNumbers.Add(i);
}

Console.WriteLine(muchosNumbers.Count);
Console.WriteLine(muchosNumbers);

int[] numsToRemove = [ ..Enumerable.Range(50, 50) ];
foreach (int a in numsToRemove)
    muchosNumbers[a] = 999;

var enumerator = muchosNumbers.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}