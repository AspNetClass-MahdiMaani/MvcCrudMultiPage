using AspNetMvcSample01.ApplicationServices.Dtos.Person;
using AspNetMvcSample01.Migrations;
using AspNetMvcSample01.Models.Frameworks.Contracts;
using AspNetMvcSample01.Models.Services;

namespace AspNetMvcSample01.ApplicationServices.Services
{
    public class PersonService : IPersonService
    {

        #region [- Ctor() -]

        private readonly PersonRepository _personRepository;
        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion


        #region [- Create() -]

        public async Task Insert(DtoPostPerson person)
        {
            var p = new DtoPostPerson();
            person.FName = person.FName;
            person.LName = person.LName;
            await _personRepository.Insert(p);
        }

        #endregion


        #region [- Select() -]

        public async Task<List<DtoGetPerson>> Select()
        {
            List<DtoGetPerson> dtoList = new List<DtoGetPerson>();
            foreach (var item in dtoList)
            {
                var dto = new DtoGetPerson();
                dto.Id = item.Id;
                dto.FName = item.FName;
                dto.LName = item.LName;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        #endregion


        #region [- Delete() -]

        public async Task Delete(long id)
        {
            await _personRepository.Delete(id);
        }

        //public Task Delete(DtoPostPerson person)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion


        #region [- Edit() -]

        public async Task Update(DtoGetPerson person)
        {
            await _personRepository.Update(person);
        }

        #endregion
    }
}
