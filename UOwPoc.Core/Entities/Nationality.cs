using UOwPoc.Core.Entities.Base;
using UOWPoc.Entities;

namespace UOwPoc.Core.Entities
{
    public class Nationality : BaseLookupEntity
    {
        public virtual ICollection<Person> Persons { get; }

        public Nationality()
        {
        }
        public Nationality(int id, string name, string uniqueName) : base(id, name, uniqueName)
        {
        }
    }
}