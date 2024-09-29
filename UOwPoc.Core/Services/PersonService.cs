using AutoMapper;
using UOwPoc.Core.Interfaces;
using UOwPoc.Core.ViewModels.Person;
using UOWPoc.Entities;

namespace UOwPoc.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public PersonVM GetById(Guid id)
        {
            var peron = _uow.QueryRepository<Person>().GetById(id);
            return _mapper.Map<PersonVM>(peron);
        }

        public List<PersonVM> GetAll()
        {
            var persons = _uow.QueryRepository<Person>().GetAll("Nationality,Addresses");
            return _mapper.Map<List<PersonVM>>(persons);
        }

        public PersonVM Add(AddPersonVM model)
        {
            var person = _mapper.Map<Person>(model);
            _uow.CommandRepository<Person>().Add(person);
            var res = _uow.SaveChanges();
            if (res > 0)
                return _mapper.Map<PersonVM>(person);
            throw new Exception("Person not added");
        }

        public PersonVM Update(UpdatePersonVM model)
        {
            var person = _uow.QueryRepository<Person>().GetById(model.Id);
            if (person == null)
                throw new Exception("Person not found");

            _mapper.Map(model, person);
            _uow.CommandRepository<Person>().Update(person);
            var res = _uow.SaveChanges();
            if (res > 0)
                return _mapper.Map<PersonVM>(person);
            throw new Exception("Person not updated");
        }

        public bool Delete(Guid id)
        {
            var person = _uow.QueryRepository<Person>().GetById(id);
            if (person == null)
            {
                throw new Exception("Person not found");
            }
            _uow.CommandRepository<Person>().Delete(person);
            var res = _uow.SaveChanges();
            return res > 0;
        }
    }
}