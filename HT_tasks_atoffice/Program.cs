using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using NamespaceA;
using NamespaceB;


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
                    // foreach (var relationship in src.Relationships)
                    for (int i = 0; i < src.Relationships.Count; i++)
                    {
                        //dest.Relationships[i] = new NamespaceB.Relationship();
            
                        dest.Relationships[i].RelationshipWith = MapManuallyAB(src.Relationships[i].RelationshipWith);
                       // dest.Relationships[i].RelationShipType[i] = src.Relationships[i].RelationShipType.ToString();
                    }
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
            for (int i = 0; i<dest.Relationships.Length; i++)
            {
                
            }
            


        }
    }
}
