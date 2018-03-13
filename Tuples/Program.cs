using System;
using static System.Console;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = OldStyle(name: "Steve", lastName: "Jobs");

            WriteLine($@"A long time ago ... item1, item2, item, item -> Fullname: {p1.Item1} {p1.Item2}");

            var p2 = Lookup(name: "Arthur", lastName: "Dante");

            WriteLine($@"But today ... named, named :) -> Fullname: {p2.name} {p2.lastName}");

            (string name, string lastName) = Lookup(name: "Bill", lastName: "Gates");

            WriteLine($@"var, why? Deconstruct it! -> Fullname: {name} {lastName}");

            ReadLine();

        }

        static Tuple<string, string> OldStyle(string name, string lastName)
            => Tuple.Create(item1: name, item2: lastName);

        static (string name, string lastName) Lookup(string name, string lastName)
            => (name, lastName);
    }
}
