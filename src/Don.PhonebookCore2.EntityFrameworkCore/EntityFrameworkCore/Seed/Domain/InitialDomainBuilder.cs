using System;
using System.Collections.Generic;
using System.Text;

namespace Don.PhonebookCore2.EntityFrameworkCore.Seed.Domain
{
    public class InitialDomainBuilder
    {
        private readonly PhonebookCore2DbContext _context;

        public InitialDomainBuilder( PhonebookCore2DbContext context)
        {
            _context = context;
        
        }

        public void Create()
        {
            new DefaultPersonsCreator(_context).Create();
            _context.SaveChanges();
        }
    }
}