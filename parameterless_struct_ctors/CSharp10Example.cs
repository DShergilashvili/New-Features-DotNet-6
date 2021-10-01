
using System;

public static class Program
{
    static void WriteValue(Person instance)
    {
        Console.WriteLine(instance.Age);
        Console.WriteLine(instance.Name); 
    }

    public static void Main()
    {
        {
            Person instance;

            // error CS0165: Use of unassigned local variable 'instance'
            // WriteValue(instance);
        }

        {
            Person instance;

            instance.Age = 31;
            instance.Name = "David";

            WriteValue(instance);
        }

        {
            Person instance = new Person();
            WriteValue(instance);
        }
    }
}

public struct Person
{
    public int Age;
    public string Name;

    public Person()
    {
        this.Age = 1;
        this.Name = "David";
    }
}

public struct Point
{
    public int X;
    public int Y;

    // error CS0522: 'Point': structs cannot call base class constructors
    public Point() // : base()
    {
        X = 0;
        Y = 0;
    }
}

public struct Vector
{
    public float X;
    public float Y;

    public Vector() : this(0.0f, 0.0f)
    {
    }

    public Vector(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
}

namespace Modifier
{
    struct S0 { }

    struct S1 { public S1() { } }

    // error CS8958: The parameterless struct constructor must be 'public'.
    // struct S2 { internal S2() { } }

    struct S4
    {
        public int intField = 5;
        public string textField = "Example1";

        public S4()
        {
            textField = "Example2";
        }
    }
}

namespace StructInStruct
{
    struct S0
    {
        public S0() { } // S0 type with constructor
    }

    struct S1
    {
        S0 F; // No S0 constructor call

        public void Default()
        {
            _ = default(S0);
        }
    }

    struct S<T> where T : struct
    {
        T F; // Even if there is a struct with a constructor with a formal argument T, it is not called
    }
}


namespace ObjectCreation
{
    struct S
    {
        public int i = 5;

        public S(int i) { this.i = i; }
    }

    public class Test
    {
        static T CreateNew<T>() where T : new() => new T();

        public void Create()
        {
            {
                S instance = new S();
                Console.WriteLine(instance.i);
            }

            {
                S instance = CreateNew<S>();
                Console.WriteLine(instance.i);
            }
        }
    }
}

namespace ObjectCreationWithCtor
{
    struct S
    {
        public int i = 5;

        public S() { i = 10; }
    }

    public class Test
    {
        static T CreateNew<T>() where T : new() => new T();

        public void Create()
        {
            S instance = CreateNew<S>();
            Console.WriteLine(instance.i);
        }
    }
}

struct Init0
{
    public int intField;
    public string textField;

    // error CS0171: Field 'Init0.intField' must be fully assigned before control is returned to the caller
    //public Init0()
    //{
    //    textField = "None";
    //}
}

struct Init1
{
    public int intField;
    public string textField;
    public float floatField = 0.5f;

    // error CS0171: Field 'Init1.textField' must be fully assigned before control is returned to the caller
    // public Init1()
    // {
    //     intField = 5;
    // }
}

struct Init2
{
    public int intField;

    // error CS0171: Field 'Init2.intField' must be fully assigned before control is returned to the caller
    // public Init2()
    // {
    // }
}

struct Init3
{
    public int intField;
    public float floatField = 0.5f;

    public Init3()
    {
        intField = 5;
    }
}

struct Init4
{
    public int intField = 5;
    public float floatField = 0.5f;

    public Init4()
    {
    }
}

struct Init4_2
{
    public float floatField = 0.5f;
    public int intField = 5;

    public Init4_2()
    {
    }
}

struct Init5
{
    public int intField;
    public float floatField;

    public Init5()
    {
        intField = 5;
        floatField = 0.5f;
    }
}

struct Init6
{
    public int intField = 5;
    public float floatField;

    public Init6()
    {
        floatField = 5.0f;
    }

    public Init6(float value)
    {
        floatField = value;
    }
}

record struct R0; // no parameterless .ctor

record struct R1  // synthesized .ctor: public R1() { F = 42; }
{
    int F = 42;
}

record struct R2(int F) // no parameterless .ctor
{
    int F = F;
}

record struct R2_2(int F) // no parameterless .ctor
{
    int f = F;
}

record struct R3(int F)
{
    public R3() : this(0) { }
    public int F = F;
}

record struct R4(int F)
{
    // error CS8862: A constructor declared in a record with parameter list must have 'this' constructor initializer.
    // public R4() { this.F = 0; }
}

record struct Student()
{
    public string Name { get; init; } = "";
    public object Id { get; init; } = DateTime.Now;

    public int Age { get; init; } = 0;
}

record class Teacher()
{
    public string Name { get; init; } = "";
    public object Id { get; init; } = DateTime.Now;

    public int Age { get; init; } = 0;
}