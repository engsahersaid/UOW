using AutoMapper;
using UOwPoc.Core.ViewModels.Address;
using UOwPoc.Core.ViewModels.Person;
using UOWPoc.Entities;

namespace UOwPoc.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPersonVM, Person>();
            CreateMap<AddAddressVM, Address>();

            CreateMap<UpdatePersonVM, Person>();
            CreateMap<UpdateAddressVM, Address>();

            CreateMap<Person, PersonVM>()
                .ReverseMap();

            CreateMap<Address, AddressVM>()
                .ReverseMap();

        }
    }
}