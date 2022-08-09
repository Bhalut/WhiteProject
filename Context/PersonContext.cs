using Microsoft.EntityFrameworkCore;
using WhiteProject.Models;

namespace WhiteProject.Context;

public class PersonContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Person> personInit = new List<Person>();
        personInit.Add(new Person() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), FirstName = "Oscar", LastName = "Mendez", Age = 25, City = "San Jose", Country = "Costa Rica", Birthday = DateTime.Parse("1996-01-01"), CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        personInit.Add(new Person() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), FirstName = "Diego", LastName = "Rodriguez", Age = 25, City = "San Jose", Country = "Costa Rica", Birthday = DateTime.Parse("1996-01-01"), CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });


        modelBuilder.Entity<Person>(categoria =>
        {
            categoria.ToTable("Person");
            categoria.HasKey(p => p.Id);
            categoria.Property(p => p.FirstName).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Age).IsRequired();
            categoria.Property(p => p.City).IsRequired();
            categoria.Property(p => p.Country).IsRequired();
            categoria.Property(p => p.Birthday).IsRequired();
            categoria.Property(p => p.CreatedDate).IsRequired();
            categoria.Property(p => p.UpdatedDate).IsRequired();


            categoria.HasData(personInit);
        });
    }

}