using Microsoft.EntityFrameworkCore;
using UserRegisteration.Entities;

namespace UserRegisteration.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
       
        public DbSet<User> users { get; set; }
        public DbSet<Contact> contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user -> contact (one to many)
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithMany(c => c.Contacts)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
     

    }
}
