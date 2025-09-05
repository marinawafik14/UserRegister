using UserRegisteration.Entities;

namespace UserRegisteration.Interfaces
{
    public interface IUnitOfWork 

    {
        IGenericRepository<User>  Users { get; }
        IGenericRepository<Contact> Contacts { get; }
        Task <int> SavechangesAsync();
    }
}
