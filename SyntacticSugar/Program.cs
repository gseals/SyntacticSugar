using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            var predator = new List<string> { "birds", " frogs" };
            var prey = new List<string> { "crops", " flowers", " grass" };
            var bug = new Bug("buggy", "beetle", predator, prey);
            
                Console.WriteLine(bug);
                Console.ReadLine();

                Console.WriteLine(bug.FormalName);
                Console.ReadLine();

                Console.WriteLine(bug.PreyList());
                Console.ReadLine();

                Console.WriteLine(bug.PredatorList());
                Console.ReadLine();

                Console.WriteLine(bug.Eat("grass"));
                Console.ReadLine();
        }
    }

    }
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        public string PreyList() => string.Join(",", this.Prey);

        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);

        // Convert this to expression method
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
}
