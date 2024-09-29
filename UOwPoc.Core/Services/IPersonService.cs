using UOwPoc.Core.ViewModels.Person;

namespace UOwPoc.Core.Services
{
    public interface IPersonService
    {
        PersonVM GetById(Guid id);

        List<PersonVM> GetAll();

        PersonVM Add(AddPersonVM model);

        PersonVM Update(UpdatePersonVM model);

        bool Delete(Guid id);
    }
}