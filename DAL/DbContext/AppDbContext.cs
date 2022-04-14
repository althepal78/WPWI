using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(u =>
            {
                u.Property(user => user.PhoneNumber)
            .IsUnicode(false)
            .IsFixedLength(false)
            .HasMaxLength(15);

                u.Property(user => user.PasswordHash)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasMaxLength(84);

                u.Property(user => user.ConcurrencyStamp)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasMaxLength(36)
                    .IsRequired(true);

                u.Property(user => user.SecurityStamp)
                    .IsUnicode(false)
                    .IsFixedLength(false)
                    .HasMaxLength(36)
                    .IsRequired(true);
            });
        }
    }
}
