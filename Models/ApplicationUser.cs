using HotspotGamingTicketingSystem.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        CreatedTickets = new HashSet<Ticket>();
        AssignedTickets = new HashSet<Ticket>();
    }

    // Other properties...

    public virtual ICollection<Ticket> CreatedTickets { get; set; }
    public virtual ICollection<Ticket> AssignedTickets { get; set; }
}

