using System;

unsafe
{
    S0 instance = new S0();
    S0* ptr = &instance;
}

unsafe
{
    S3 instance;
    instance.intField = 5;

    S3* p = &instance;
}


unsafe
{
    S4 instance;

    instance.intField = 5;

    //  error CS0208: Cannot take the address of, get the size of, or declare a pointer to a managed type ('S4')
    // S4* p = &instance;
}

unsafe
{
    //S4* p = & instance;
    //{
    //    WriteValue(instance);
    //}
}

Console.WriteLine();

struct S0 { }

// C# 9 compile error below
// struct S1 { public S1() { } }

// C# 9 compile error below
// struct S2 { internal S2() { } } // error: parameterless constructor must be 'public'

struct S3
{
    public int intField;
    public float floatField;
}

struct S4
{
    public int intField;
    public string textField;
}