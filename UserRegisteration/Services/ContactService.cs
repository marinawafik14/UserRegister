using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using UserRegisteration.DTOs;
using UserRegisteration.Entities;
using UserRegisteration.Interfaces;

namespace UserRegisteration.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public ContactService(IUnitOfWork unitOfWork , IMapper mapper ) 
        {
        this._unitOfWork = unitOfWork;
            this._map = mapper;
        }
        public async Task<ContactDto> AddContact(ContactDto dto, int userId)
        {
            var contact = _map.Map<Contact>(dto);
            contact.UserId = userId;
            await _unitOfWork.Contacts.AddAsync(contact);
            await _unitOfWork.SavechangesAsync();
            return _map.Map<ContactDto>(contact);

        }

        public async Task<IEnumerable<ContactDto>> GegAllContacts(int userid)
        {
            var contacts =  (await _unitOfWork.Contacts.GetAllAsync()).Where(w => w.UserId == userid);
            return _map.Map<IEnumerable<ContactDto>>(contacts);   
        }

        public async Task<ContactDto> GetContactById(int id, int userId)

        {
            var contact = await _unitOfWork.Contacts.GetById(id);
            if (contact == null || contact.UserId != userId) return null;

            return _map.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> UpdateContact(ContactDto dto, int id, int userId)
        {
            var contactExiting = await _unitOfWork.Contacts.GetById(id);
            if (contactExiting == null || contactExiting.UserId != userId) return null;
            contactExiting.FirstName = dto.FirstName;
            contactExiting.LastName = dto.LastName;
            contactExiting.Email = dto.Email;
            contactExiting.PhoneNumber = dto.PhoneNumber;
            contactExiting.Birthdate = dto.Birthdate;
            await _unitOfWork.SavechangesAsync();
            return _map.Map<ContactDto>(dto);

        }

        async Task<bool> IContactService.DeleteAsync(int id, int userId)
        {
            var contact = await _unitOfWork.Contacts.GetById(id);
            if (contact == null || contact.UserId != userId) return false;

            _unitOfWork.Contacts.DeleteAsync(id);
            await _unitOfWork.SavechangesAsync();
            return true;


        }
    }
}
