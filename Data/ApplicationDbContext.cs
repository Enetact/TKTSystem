using HotspotGamingTicketingSystem.Models; // Correct namespace
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotspotGamingTicketingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketAssignment> TicketAssignments { get; set; }
        public virtual ICollection<Ticket> CreatedTickets { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedToUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public async Task ReassignTicketsAndDeleteUser(string userId, string newUserId)
        {
            var tickets = Tickets.Where(t => t.CreatedByUserId == userId || t.AssignedToUserId == userId);
            foreach (var ticket in tickets)
            {
                if (ticket.CreatedByUserId == userId)
                    ticket.CreatedByUserId = newUserId;
                if (ticket.AssignedToUserId == userId)
                    ticket.AssignedToUserId = newUserId;
            }
            await SaveChangesAsync();

            var user = Users.Find(userId);
            Users.Remove(user);
            await SaveChangesAsync();
        }

        public async Task NullifyUserAndDelete(string userId)
        {
            var tickets = Tickets.Where(t => t.CreatedByUserId == userId || t.AssignedToUserId == userId);
            foreach (var ticket in tickets)
            {
                if (ticket.CreatedByUserId == userId)
                    ticket.CreatedByUserId = null;
                if (ticket.AssignedToUserId == userId)
                    ticket.AssignedToUserId = null;
            }
            await SaveChangesAsync();

            var user = Users.Find(userId);
            Users.Remove(user);
            await SaveChangesAsync();
        }

        public async Task DeleteUserAndTickets(string userId)
        {
            var tickets = Tickets.Where(t => t.CreatedByUserId == userId || t.AssignedToUserId == userId);
            Tickets.RemoveRange(tickets);
            await SaveChangesAsync();

            var user = Users.Find(userId);
            Users.Remove(user);
            await SaveChangesAsync();
        }
    }
    public class ApplicationUser : IdentityUser
    {
        // Other properties...

        public virtual ICollection<Ticket> CreatedTickets { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
    }
}

