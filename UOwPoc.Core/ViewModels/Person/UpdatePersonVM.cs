using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOwPoc.Core.ViewModels.Address;

namespace UOwPoc.Core.ViewModels.Person
{
    public class UpdatePersonVM
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }

        public IList<UpdateAddressVM>? Addresses { get; init; }
    }
}
