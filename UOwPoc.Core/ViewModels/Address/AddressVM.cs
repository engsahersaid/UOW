namespace UOwPoc.Core.ViewModels.Address
{
    public class AddressVM
    {
        public Guid Id { get; init; }
        public string Country { get; init; }
        public string POBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
    }
}