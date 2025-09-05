using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegisteration.Interfaces;
using UserRegisteration.Entities;
using UserRegisteration.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace UserRegisteration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;
      
       private int GetUserId() => int.Parse(User.FindFirst("UserId").Value);
        public ContactsController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        // get contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
           var contacts= await _contactService.GegAllContacts(GetUserId());
            return Ok(contacts);
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactService.GetContactById(id , GetUserId());
            if (contact == null ) return NotFound();
            return Ok(contact);

        }

        // delete contact
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result =  await _contactService.DeleteAsync(id , GetUserId());
            if (!result) return NotFound();
            return Ok("Deleted successfully");
        }
        // add contact
        [HttpPost]
        public async Task<IActionResult> AddContact (ContactDto contactdto)
        {

            var contact = await _contactService.AddContact(contactdto , GetUserId());
            return Ok(contact);
        }

        //update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id ,ContactDto contactdto)
        {
            var contact = await _contactService.UpdateContact(contactdto,id,GetUserId());
            if (contact == null) return NotFound();
            return Ok(contact);
        }
    }

}
