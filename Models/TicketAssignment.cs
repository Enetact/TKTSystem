using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotspotGamingTicketingSystem.Models
{
    public class TicketAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Assigned To")]
        public string? AssignedToUserId { get; set; }

        [ForeignKey("AssignedToUserId")]
        public virtual ApplicationUser? AssignedToUser { get; set; }

        [Required]
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }

        [Display(Name = "Assignment Date")]
        [DataType(DataType.DateTime)]
        public DateTime AssignmentDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status")]
        public AssignmentStatus Status { get; set; } = AssignmentStatus.Assigned;
    }

    public enum AssignmentStatus
    {
        Assigned,
        InProgress,
        Completed
    }
}
