using System.Linq;
using Don.PhonebookCore2.Domain.Persons;

namespace Don.PhonebookCore2.EntityFrameworkCore.Seed.Domain
{
    public class DefaultPersonsCreator
    {
        private readonly PhonebookCore2DbContext _context;

        public DefaultPersonsCreator(PhonebookCore2DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
        }
    }
}