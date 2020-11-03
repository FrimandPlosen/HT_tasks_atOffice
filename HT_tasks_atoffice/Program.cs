using NamespaceA;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HT_tasks_atoffice
{
    class Program
    {
        public static NamespaceA.Person MapManuallyBA(NamespaceB.Person src)
        {
            NamespaceA.Person dest = new NamespaceA.Person();

            if (src == null)
                return null;


            return null;
        }

        public static NamespaceB.Person MapManuallyAB(NamespaceA.Person src)
        {
            NamespaceB.Person dest = new NamespaceB.Person();

            if (src == null)
            {
                return null;
            }
            else
            {
                dest.Name = src.FirstName + " " + src.LastName;

                bool isParseable = Int32.TryParse(src.YearOfBirth, out int yearOfBirth);
                if (isParseable == true)
                {
                    dest.Age = DateTime.Now.Year - yearOfBirth;
                }
                else
                {
                    Console.WriteLine("NamespaceA Year of Birth is not a number");
                }

                dest.Sex = src.Sex.ToString();

                if (src.Relationships != null)
                {
                    dest.Relationships = new NamespaceB.Relationship[src.Relationships.Count];

                    for (int i = 0; i < src.Relationships.Count(); i++)
                    {
                        dest.Relationships[i] = new NamespaceB.Relationship();
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

                dest.RelationShipType = new string[src.RelationShipType.Count()];
                for (int i = 0; i < src.RelationShipType.Count(); i++)
                {
                    dest.RelationShipType[i] = src.RelationShipType[i].ToString();
                }
                return dest;
            }
        }


        static void Main(string[] args)
        {
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
            
            NamespaceB.Person dest = MapManuallyAB(test2);
            Console.WriteLine("Name: " + dest.Name);
            Console.WriteLine("Age: " + dest.Age);
            Console.WriteLine("Sex: " + dest.Sex);
            for (int i = 0; i < dest.Relationships.Length; i++)
            {
                Console.WriteLine("Relationship: " + dest.Relationships[i].RelationshipWith.Name);
                Console.WriteLine("Relationship Type: " + dest.Relationships[i].RelationShipType[i]);
            }



        }
    }
}
