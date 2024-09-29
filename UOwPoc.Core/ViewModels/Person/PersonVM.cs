using UOwPoc.Core.ViewModels.Address;

namespace UOwPoc.Core.ViewModels.Person
{
    public class PersonVM
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public string NationalityName { get; init; }
        public IList<AddressVM>? Addresses { get; init; }
    }
}