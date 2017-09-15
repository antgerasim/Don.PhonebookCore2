using System.Collections.Generic;
using System.Linq;
using Don.PhonebookCore2.Domain.Persons;
using Don.PhonebookCore2.Domain.Phones;


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
                        EmailAddress = "douglas.adams@fortytwo.com",
                        Phones = new List<Phone>()
                        {
                            new Phone() {Type = PhoneType.Home, Number = "1234567"},
                            new Phone() {Type = PhoneType.Mobile, Number = "21547841"}
                        }
                    });

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org",
                        Phones = new List<Phone>()
                        {
                            new Phone() {Type = PhoneType.Home, Number = "8451223"},
                            new Phone() {Type = PhoneType.Mobile, Number = "8451244"}
                        }
                    });
        }
    }
}