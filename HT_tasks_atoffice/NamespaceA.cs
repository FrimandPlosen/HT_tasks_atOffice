using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceA
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public List<Relationship> Relationships { get; set; }
    }

    public class Relationship
    {
        public Person RelationshipWith { get; set; }
        public List<RelationShipType> RelationShipType { get; set; }
    }

    public enum RelationShipType
    {
        Friend,
        Familiy,
        Partner,
        Dating,
        Complicated,
        Married,
        Other
    }

    public enum Sex
    {
        Male,
        Female
    }
}
