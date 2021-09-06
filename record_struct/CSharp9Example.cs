using System;

namespace ExampleCsharp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("David", 30);
            Person p2 = new Person("David", 31);

            Console.WriteLine(p1 + p2);
        }
    }
}

struct Member
{
    public string Name;
    public int Age;

    public static Member operator +(Member first, Member second)
    {
        if (first.Name != second.Name)
        {
            return first;
        }

        return new Member { Name = first.Name, Age = first.Age + second.Age };
    }
}

record Person(string Name, int Age)
{
    public static Person operator +(Person first, Person second)
    {
        if (first.Name != second.Name)
        {
            return first;
        }

        return first with { Age = first.Age + second.Age };
    }
}
