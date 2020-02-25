using Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AllIntegers");
            Iterator iterator = new IntegerIterator();
            int i = 1;
            while (iterator.MoveNext())
            {
                Console.WriteLine($"{i++}: {iterator.Current}");
                if (i == 10) break;
            }
            Console.WriteLine("AllIntegers FOREACH");
            iterator.Reset();
            i = 1;
            foreach (int j in iterator)
            {
                Console.WriteLine($"{i++}: {iterator.Current}");
                if (i == 10) break;
            }

            Console.WriteLine("Square(AllIntegers)");
            iterator = new SquareIterator(new IntegerIterator());
            i = 1;
            while (iterator.MoveNext())
            {
                Console.WriteLine($"{i++}: {iterator.Current}");
                if (i == 10) break;
            }
            Console.WriteLine("Square(AllIntegers) FOREACH");
            iterator.Reset();
            i = 1;
            foreach (int j in iterator)
            {
                Console.WriteLine($"{i++}: {iterator.Current}");
                if (i == 10) break;
            }

            Console.WriteLine("Take(10, Square(AllIntegers))");
            iterator = new TakeIterator(10, new SquareIterator(new IntegerIterator()));
            i = 1;
            while (iterator.MoveNext())
                Console.WriteLine($"{i++}: {iterator.Current}");
            Console.WriteLine("Take(10, Square(AllIntegers)) FOREACH");
            iterator.Reset();
            i = 1;
            foreach (int j in iterator)
                Console.WriteLine($"{i++}: {iterator.Current}");

            SomeClass some = new SomeClass()
            {
                IntValue = 5,
                StringValue = "Hello",
                DateTimeValue = DateTime.Now
            };
            PropertyIterator<SomeClass> propIterator = new PropertyIterator<SomeClass>(some);
            foreach (PropertyValue propertyValue in propIterator)
                Console.WriteLine($"{propertyValue.Value.GetType().Name}: {propertyValue.Value}");

            Console.Write("Press any key to continue. . .");
            Console.ReadKey();
        }
    }
}
