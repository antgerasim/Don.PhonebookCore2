namespace Don.PhonebookCore2.EntityFrameworkCore.Seed.Domain
{
    public class DefaultPhonesCreator
    {
        private readonly PhonebookCore2DbContext _context;

        public DefaultPhonesCreator(PhonebookCore2DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            
        }
    }
}