using WhiteProject.Models;
using WhiteProject.Context;

namespace WhiteProject.Services;

public class PersonService : IPersonService
{
    private readonly PersonContext _context;

    public PersonService(PersonContext context)
    {
        _context = context;
    }

    public async Task Create(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Person person)
    {
        var current = _context.Persons.Find(id);

        if (current != null)
        {
            // current.Nombre = categoria.Nombre;
            // current.Descripcion = categoria.Descripcion;
            // current.Peso = categoria.Peso;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var current = _context.Persons.Find(id);

        if (current != null)
        {
            _context.Persons.Remove(current);
            await _context.SaveChangesAsync();
        }
    }

    public Person GetPerson(Guid id)
    {
        return _context.Persons.Find(id);
    }

    public IEnumerable<Person> GetPersons()
    {
        return _context.Persons;
    }
}

public interface IPersonService
{
    public Task Create(Person person);
    public Task Update(Guid id, Person person);
    public Task Delete(Guid id);
    public Person GetPerson(Guid id);
    public IEnumerable<Person> GetPersons();
}