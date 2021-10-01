# LINQ update in .NET 6

In .NET 6, better support will be provided for Linq. The functions that we may have implemented through custom extension methods before are now officially supported directly.
Linq will be more powerful and better help us simplify the application code.

## Better Index & Range support

`Index` and `Range` is a feature introduced in C# 8.0, which can help us better locate the position of elements or perform slicing operations on the basis of the original collection. .NET 6 will better support `Index` and The `Range` feature and better support for Linq, look at the following example:

``` c#
Enumerable.Range(1, 10).ElementAt(^2); // returns 9
Enumerable.Range(1, 10).Take(^2..); // returns [9,10]
Enumerable.Range(1, 10).Take(..2); // returns [1,2]
Enumerable.Range(1, 10).Take(2..4); // returns [3,4]
```

## By Clause

.NET 6 will introduce `By` to support operations such as `Max`/`Min`/`Union`/`Distinct`/`Intersect`/`Except` according to the elements in the collection.

``` c#
// DistinctBy/UnionBy/IntersectBy/ExceptBy
Enumerable.Range(1, 20).DistinctBy(x => x% 3); // [1, 2, 3]
var first = new (string Name, int Age)[] { ("David", 31), ("Lasha", 30), ("Bondo", 40) };
var second = new (string Name, int Age)[] { ("Bidzina", 30), ("Irakli", 30), ("Giorgi", 33) };
first.UnionBy(second, person => person.Age).Select(x => $"{x.Name}, {x.Age}"); // { ("David", 20), ("Lasha", 30), ("Bondo", 40), ("Giorgi", 33) }

``` c#
// MaxBy/MinBy
var people = new (string Name, int Age)[] { ("Davida", 20), ("Lashuna", 30), ("Bondo", 40) };
people.MaxBy(person => person.Age); ; // ("Bondo", 40)
people.MinBy(x => x.Name); // ("Bondo", 40)
```

## Chuck

This function has been awaited for a long time. Simply put, it is to group a collection by BatchSize. After grouping, the number of elements in each small collection is at most BatchSize. Before we wrote an extension method to achieve it, we can use this extension method directly. Now, look at the following example to understand:

``` c#
var list = Enumerable.Range(1, 10).ToList();
var chucks = list.Chunk(3);

// [[1,2,3],[4,5,6],[7,8,9],[10]]
```

## Default enhancement

For the extension methods `FirstOrDefault`/`LastOrDefault`/`SingleOrDefault`, in the previous version, we could not specify the default value. If we encounter Default, we will use the default value of the generic type. After NET 6, we can specify a default value, an example is as follows:

``` c#
Enumerable.Empty<int>().FirstOrDefault(-1);
Enumerable.Empty<int>().SingleOrDefault(-1);
Enumerable.Empty<int>().LastOrDefault(-1);
```

## Zip enhancement

``` c#
var xs = Enumerable.Range(1, 5).ToArray();
var ys = xs.Select(x => x.ToString());
var zs = xs.Select(x => x% 2 == 0);

foreach (var (x,y,z) in xs.Zip(ys, zs))
{
     Console.WriteLine($"{x},{y},{z}");
}
```

The output is as follows:

``` sh
1,1,False
2,2,True
3,3,False
4,4,True
5,5,False
```

## More

In addition to the above update, Microsoft also provides a `TryGetNonEnumeratedCount(out int count)` method to try to obtain the `Count`, so that if the `IEnumerable<T>` is an `ICollection` object, the `Count can be obtained more efficiently `Instead of calling the `Count()` extension method, no need to traverse the `IEnumerable` object

In addition, for the original Min/Max extension method, .NET 6 will add an overload, which makes it easier to specify a comparator

``` c#
public static TSource Min<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer);
public static TSource Max<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer);
public static TSource Min<TSource>(this IQueryable<TSource> source, IComparer<TSource> comparer);
public static TSource Max<TSource>(this IQueryable<TSource> source, IComparer<TSource> comparer);
```

## References
-<https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/#system-linq-enhancements>