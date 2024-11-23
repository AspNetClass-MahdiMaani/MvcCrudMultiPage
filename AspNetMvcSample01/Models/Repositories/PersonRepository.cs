using AspNetMvcSample01.ApplicationServices.Dtos.Person;
using AspNetMvcSample01.Migrations;
using AspNetMvcSample01.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcSample01.Models.Services
{
    public class PersonRepository
    {

        #region [- ctor() -]

        private readonly ProjectDbContext _context;
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        }
        #endregion


        #region [- Select() -]

        public async Task<List<Person>> Select()
        {
            try
            {
                var q = await _context.DtoGetPerson.ToListAsync();
                return q;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_context == null)
                {
                    _context.Dispose();
                }
            }
        }
        #endregion


        #region [- Create() -]

        public async Task Insert(DtoGetPerson person)
        {
            try
            {
                _context.DtoGetPerson.Add(person);
                 _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
        #endregion


        #region [- Update() -]
        public async Task Update(DtoGetPerson person)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(person).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context != null)
                    {
                        await _context.DisposeAsync();
                    }
                }

            }

        }
        #endregion


        #region [- Delete() -]

        public async Task Delete(long Id)
        {
            using (_context)
            {
                try
                {
                    var q= _context.DtoGetPerson.Find(Id);
                    _context.DtoGetPerson.Remove(q);
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }

            }
        }
        #endregion


        #region [- FindId(long? id) -]
        public async Task<DtoGetPerson> FindId(long? id)
        {
            using (_context)
            {
                try
                {
                    var q = _context.DtoGetPerson.Find(id);
                    return q;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            }
        }
        #endregion

    }

}
