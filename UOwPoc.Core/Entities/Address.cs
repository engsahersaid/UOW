using System.ComponentModel.DataAnnotations.Schema;
using UOwPoc.Core.Entities.Base;

namespace UOWPoc.Entities
{
    public class Address : BaseAuditableEntity
    {
        public string Country { get; init; }
        public string POBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
        //[ForeignKey("Person")]
        public Guid PersonId { get; init; }
        public virtual Person Person { get; init; }

        public Address():base(Guid.NewGuid())
        {
        }
        public Address(Guid id, string country, string poBox, string city, string street, string apartment) : base(id)
        {
            Id = id;
            Country = country;
            POBox = poBox;
            City = city;
            Street = street;
            Apartment = apartment;
        }
        public Address(Guid id, Guid personId, string country, string poBox, string city, string street, string apartment) : this(id, country, poBox, city, street, apartment)
        {
            PersonId = personId;
        }
        public override string ToString()
        {
            return $"{nameof(Country)}: {Country}, {nameof(POBox)}: {POBox}, {nameof(City)}: {City}, {nameof(Street)}: {Street}, {nameof(Apartment)}: {Apartment}";
        }
    }
}