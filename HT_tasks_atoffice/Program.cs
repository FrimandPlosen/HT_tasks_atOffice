using NamespaceA;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HT_tasks_atoffice
{
    class Program
    {

        public static NamespaceB.Person MapManuallyAB(NamespaceA.Person src)        //Maps the Person object from NamespaceA -> NamespaceB
        {
            NamespaceB.Person dest = new NamespaceB.Person();

            if (src == null)                                                        // Makes sure code doesnt run if there isnt a person to map
            {
                return null;
            }
            else
            {
                dest.Name = src.FirstName + " " + src.LastName;                     // Combines FirstName and LastName into one string

                bool isParseable = Int32.TryParse(src.YearOfBirth, out int yearOfBirth);    //checks to see if the string "YearOfBirth" is a number, and stores it in a int
                if (isParseable == true)
                {
                    dest.Age = DateTime.Now.Year - yearOfBirth;                         // if it is, calculates age from current date and yearOfBirth
                }
                else
                {
                    Console.WriteLine("NamespaceA Year of Birth is not a number");
                }

                dest.Sex = src.Sex.ToString();                                              // uses an enum function to turn it to a string.

                if (src.Relationships != null)                                              // check to make sure code doesnt run if the person does not have any relationships
                {
                    dest.Relationships = new NamespaceB.Relationship[src.Relationships.Count];  // creates new Array in the NamespaceB object with same length as the amount of elements
                                                                                                // in NamespaceA list
                    for (int i = 0; i < src.Relationships.Count(); i++)
                    {
                        dest.Relationships[i] = new NamespaceB.Relationship();                  // Creates a new object in the array to store info in
                        dest.Relationships[i] = MapManuallyAB(src.Relationships[i]);          
                    }
                }
                return dest;
            }
        }
        public static NamespaceB.Relationship MapManuallyAB(NamespaceA.Relationship src)
        {
            if (src == null)
            {
                return null;
            }
            else
            {
                NamespaceB.Relationship dest = new NamespaceB.Relationship();
                dest.RelationshipWith = MapManuallyAB(src.RelationshipWith);

                if (src.RelationShipType != null)
                {
                    dest.RelationShipType = new string[src.RelationShipType.Count()];
                    for (int i = 0; i < src.RelationShipType.Count(); i++)
                    {
                        dest.RelationShipType[i] = src.RelationShipType[i].ToString();
                    }
                }
                return dest;
            }
        }
        public static NamespaceA.Person MapManuallyBA(NamespaceB.Person src)
        {
            NamespaceA.Person dest = new Person();

            if (src == null)
            {
                return null;
            }

            string[] split = src.Name.Split(' ');
            dest.FirstName = split[0];
            dest.LastName = split[1];

            int yearOfBirth = DateTime.Now.Year - src.Age;
            dest.YearOfBirth = yearOfBirth.ToString();
            
            bool isParseable = Enum.TryParse(src.Sex, out Sex sex);
            if (isParseable == true)
            {
                dest.Sex = sex;
            }

            if (src.Relationships != null)
            {
                dest.Relationships = new List<Relationship>();
                for (int i = 0; i < src.Relationships.Length; i++)
                {
                    dest.Relationships.Add(MapManuallyBA(src.Relationships[i]));
                }
            } 
            return dest;
         }
        public static NamespaceA.Relationship MapManuallyBA(NamespaceB.Relationship src)
        {
            if (src == null)
            {
                return null;
            }

            NamespaceA.Relationship dest = new Relationship();
            dest.RelationshipWith = MapManuallyBA(src.RelationshipWith);
            
            dest.RelationShipType = new List<RelationShipType>();
            if (src.RelationShipType != null)
            {
                for (int i = 0; i < src.RelationShipType.Length; i++)
                {
                    bool isParseable = Enum.TryParse(src.RelationShipType[i], out RelationShipType relationshiptype);
                    if (isParseable == true)
                    {
                        dest.RelationShipType.Add(relationshiptype);
                    }
                }
            }
            return dest;
        }


        static void Main(string[] args)
        {
            NamespaceB.Person test1 = new NamespaceB.Person
            {
                Age = 30,
                Name = "Joachim Hansen",
                Sex = "Male",
                Relationships = new NamespaceB.Relationship[]
                 {
                     new NamespaceB.Relationship
                     {
                          RelationshipWith = new NamespaceB.Person
                          {
                               Age = 27,
                               Name = "Jonas Berg",
                               Sex = "Male",
                               Relationships = null,


                          },
                          RelationShipType = new string[]
                          {
                                "Friend"
                          }
                     }
                 }
            };
            NamespaceA.Person person1 = MapManuallyBA(test1);
            Console.WriteLine("First Name: " + person1.FirstName);
            Console.WriteLine("Last Name: " + person1.LastName);
            Console.WriteLine("Year of Birth: " + person1.YearOfBirth);
            Console.WriteLine("Sex: " + person1.Sex);
            for (int j = 0; j<person1.Relationships.Count; j++)
            {
                Console.WriteLine("Relationships: " + person1.Relationships[j].RelationshipWith.FirstName
                                              + " " + person1.Relationships[j].RelationshipWith.LastName);
                Console.WriteLine("Relationship Type: " + person1.Relationships[j].RelationShipType[j]);
            }
       
            NamespaceA.Person test2 = new NamespaceA.Person
            {
                FirstName = "Joachim",
                LastName = "Hansen",
                Sex = Sex.Male,
                YearOfBirth = "1990",
                Relationships = new List<NamespaceA.Relationship>
                 {
                      new NamespaceA.Relationship()
                      {
                            RelationshipWith = new NamespaceA.Person
                            {
                                 FirstName = "Jonas",
                                 LastName = "Berg",
                                 Sex = Sex.Male,
                                 YearOfBirth = "1993",
                                 Relationships = null,

                            },
                             RelationShipType = new List<RelationShipType>
                             {
                                  RelationShipType.Friend,
                             }
                      }
                 }
            };
            
            NamespaceB.Person person2 = MapManuallyAB(test2);
            Console.WriteLine("////////////////////////////////////");
            Console.WriteLine("Name: " + person2.Name);
            Console.WriteLine("Age: " + person2.Age);
            Console.WriteLine("Sex: " + person2.Sex);
            for (int i = 0; i < person2.Relationships.Length; i++)
            {
                Console.WriteLine("Relationship: " + person2.Relationships[i].RelationshipWith.Name);
                Console.WriteLine("Relationship Type: " + person2.Relationships[i].RelationShipType[i]);
            }
        }
    }
}
