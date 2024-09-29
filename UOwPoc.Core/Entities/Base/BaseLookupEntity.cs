namespace UOwPoc.Core.Entities.Base
{
    public abstract class BaseLookupEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; } = "";
        public string UniqueName { get; private set; } = "";
        public bool Active { get; private set; } = true;

        protected BaseLookupEntity()
        {
        }
        protected BaseLookupEntity(int id, string name, string uniqueName)
        {
            Id = id;
            Name = name;
            UniqueName = uniqueName;
            Active = true;
        }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}