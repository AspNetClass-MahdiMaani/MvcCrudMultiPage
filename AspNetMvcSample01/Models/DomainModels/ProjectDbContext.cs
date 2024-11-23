using AspNetMvcSample01.ApplicationServices.Dtos.Person;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcSample01.Models.DomainModels
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DtoGetPerson>? DtoGetPerson { get; set; }
    }
}
