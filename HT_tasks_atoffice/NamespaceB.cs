namespace NamespaceB
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public Relationship[] Relationships { get; set; }
    }

    public class Relationship
    {
        public Person RelationshipWith { get; set; }
        public string[] RelationShipType { get; set; }
    }
}
