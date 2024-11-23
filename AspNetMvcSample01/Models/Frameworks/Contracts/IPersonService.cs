using AspNetMvcSample01.ApplicationServices.Dtos.Person;
using AspNetMvcSample01.Migrations;
using AspNetMvcSample01.Models.Services;

namespace AspNetMvcSample01.Models.Frameworks.Contracts
{
    public interface IPersonService
    {
        Task Insert(DtoPostPerson person);
        Task<List<DtoGetPerson>> Select();
        Task Delete(long Id);
        //Task Delete(DtoPostPerson person);
        Task Update(DtoGetPerson person);
    }
}
