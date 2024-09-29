using Microsoft.AspNetCore.Mvc;
using UOwPoc.Core.Services;
using UOwPoc.Core.ViewModels.Person;

namespace UOWPoc.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public PersonVM GetById(Guid id)
        {
            return _personService.GetById(id);
        }

        [HttpGet]
        public List<PersonVM> GetAll()
        {
            return _personService.GetAll();
        }

        [HttpPost]
        public PersonVM Add([FromBody] AddPersonVM model)
        {
            return _personService.Add(model);
        }

        [HttpPut]
        public PersonVM Update([FromBody] UpdatePersonVM model)
        {
            return _personService.Update(model);
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            return _personService.Delete(id);
        }
    }
}