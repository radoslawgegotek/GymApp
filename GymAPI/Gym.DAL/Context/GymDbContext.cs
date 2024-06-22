using Gym.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.DAL.Context
{
    public class GymDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Club> Gyms { get; set; }
        public DbSet<ClubTicketType> ClubTicketTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }


        public GymDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ticket>()
                .HasOne(t => t.TicketType)
                .WithMany()
                .HasForeignKey(t => t.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntitySoftDelete>())
            //{
            //    if (entry.State == EntityState.Deleted)
            //    {
            //        entry.State = EntityState.Modified;
            //        entry.Entity.DeletedOn = DateTime.Now;
            //        entry.Entity.IsDeleted = true;
            //    }
            //}

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
