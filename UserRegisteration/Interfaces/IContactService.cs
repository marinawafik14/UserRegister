using UserRegisteration.DTOs;
using UserRegisteration.Entities;

namespace UserRegisteration.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GegAllContacts(int id);
        Task<ContactDto> GetContactById (int id , int userId);
        Task <ContactDto> AddContact (ContactDto contact , int userId);
        Task<bool> DeleteAsync (int id , int userId);
        Task<ContactDto> UpdateContact (ContactDto contact , int id, int userId);
    }
}
