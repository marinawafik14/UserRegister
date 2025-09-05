using UserRegisteration.DBContext;
using UserRegisteration.Entities;
using UserRegisteration.Interfaces;
using UserRegisteration.Repositories;

namespace UserRegisteration.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<User> Users { get; }
        public IGenericRepository<Contact> Contacts { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(context);
            Contacts = new GenericRepository<Contact>(context);
        }

      
        public async Task<int> SavechangesAsync()
        {
           return  await _context.SaveChangesAsync();
        }
    }


}
    

