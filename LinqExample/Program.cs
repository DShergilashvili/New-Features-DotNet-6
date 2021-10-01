using System;
using System.Linq;

// Index/Range support
Enumerable.Range(1, 10).ElementAt(^2); // returns 9
Enumerable.Range(1, 10).Take(^2..); // returns [9,10]
Enumerable.Range(1, 10).Take(..2); // returns [1,2]
Enumerable.Range(1, 10).Take(2..4); // returns [3,4]

// DistinctBy/UnionBy/IntersectBy/ExceptBy
Enumerable.Range(1, 20).DistinctBy(x => x % 3); // {1, 2, 3}
var first = new (string Name, int Age)[] { ("David", 31), ("Lasha", 30), ("Bondo", 40) };
var second = new (string Name, int Age)[] { ("Bidzina", 30), ("Irakli", 30), ("Giorgi", 33) };
first.UnionBy(second, person => person.Age).Select(x => $"{x.Name}, {x.Age}"); // { ("David", 20), ("Lasha", 30), ("Bondo", 40), ("Giorgi", 33) }

// MaxBy/MinBy
var people = new (string Name, int Age)[] { ("Davida", 20), ("Lashuna", 30), ("Bondo", 40) };
people.MaxBy(person => person.Age); ; // ("Bondo", 40)
people.MinBy(x => x.Name); // ("Bondo", 40)

// Chunk
var list = Enumerable.Range(1, 10).ToList();
var chucks = list.Chunk(3);

// FirstOrDefault/LastOrDefault/SingleOrDefault
Enumerable.Empty<int>().FirstOrDefault(-1);
Enumerable.Empty<int>().SingleOrDefault(-1);
Enumerable.Empty<int>().LastOrDefault(-1);

// Zip
var xs = Enumerable.Range(1, 5).ToArray();
var ys = xs.Select(x => x.ToString());
var zs = xs.Select(x => x % 2 == 0);

foreach (var (x, y, z) in xs.Zip(ys, zs))
{
    Console.WriteLine($"{x},{y},{z}");
}
