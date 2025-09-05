using System.ComponentModel.DataAnnotations;

namespace UserRegisteration.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{3,}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$",
        ErrorMessage = "Password must be at least 6 characters long and contain both letters and numbers.")]
        public string PasswordHash { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
