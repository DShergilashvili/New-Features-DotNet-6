
namespace ExampleCsharp10
{
    class Program
    {
        public string Name { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("GAMARJOBA!");

            PersonStruct person = new() { FirstName = "David", LastName = "Shergilashvili" };
        }
    }
}

record struct PersonStruct(string FirstName, string LastName);

record class PersonClass(string FirstName, string LastName);

/*
public class Person3
{
    public string Name
    {
        get; 
        
        init
        {
            field = value;
        }
    }
}
*/

// .NET 5+ Compilation errors do not occur even if the type definitions below are included in the above.
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {
    }
}
