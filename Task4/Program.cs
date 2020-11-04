using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespaceA;
using NamespaceB;
using System.Runtime.Remoting.Channels;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NamespaceA.class1, NamespaceB.class1>()); // Sets up the automapper to go from NamespaceA -> NamespaceB
            
            NamespaceA.class1 Aclass1 = new NamespaceA.class1           // Test data
            {
                Foo = "I am from Namespace A",
                Bar = 1,
                Baz = new NamespaceA.class2
                {
                    Qux = 'a',
                    Quux = new NamespaceA.class3
                    {
                        Garply = 1.1m,
                        Waldo = true
                    }

                }
                
            };

            Console.WriteLine("Data from NamespaceA: Foo: " + Aclass1.Foo + ", Bar: " + Aclass1.Bar + ", Qux: " + Aclass1.Baz.Qux       //Displays Test Data from the NamespaceA object to make sure it initalised properly
                              + ", Garply: " + Aclass1.Baz.Quux.Garply + ", Waldo: " + Aclass1.Baz.Quux.Waldo);
            
            NamespaceB.class1 Bclass1 = new NamespaceB.class1 { };
            var mapper = config.CreateMapper();                             // Creates the mapper instnace
            Bclass1 = mapper.Map<NamespaceB.class1>(Aclass1);               // Maps over to a object in NamespaceB

            Console.WriteLine("Data from NamespaceB: Foo: " + Bclass1.Foo + ", Bar: " + Bclass1.Bar + ", Qux: " + Bclass1.Baz.Qux       // displays mapped over data for easy comparison to data in NamespaceA object
                              + ", Garply: " + Bclass1.Baz.Quux.Garply + ", Waldo: " + Bclass1.Baz.Quux.Waldo);
        }
    }
}
