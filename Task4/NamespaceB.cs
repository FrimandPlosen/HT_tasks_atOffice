namespace NamespaceB
{
    public class class1
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
        public class2 Baz { get; set; }

    }

    public class class2
    {
        public char Qux { get; set; }
        public class3 Quux { get; set; }

    }

    public class class3
    {
        public decimal Garply { get; set; }
        public bool Waldo { get; set; }
    }
}
