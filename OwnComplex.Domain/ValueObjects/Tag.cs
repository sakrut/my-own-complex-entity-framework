namespace OwnComplex.Domain.ValueObjects
{
    public class Tag
    {
        public string Name { get; private set; } = null!;

        public static Tag Random()
        {
            return new Tag()
            {
                Name = $"Tag {Guid.NewGuid()}"
            };
        }
        public static Tag Create(string name)
        {
            return new Tag()
            {
                Name = name
            };
        }

        public override string ToString()
        {
            return $"       Tag (name= {Name})";
        }
    }
}
