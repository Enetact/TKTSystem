using System.ComponentModel.DataAnnotations;

namespace HotspotGamingTicketingSystem.Models
{
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status name is required.")]
        [StringLength(50, ErrorMessage = "Status name cannot exceed 50 characters.")]
        [Display(Name = "Status Name")]
        public required string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        [Display(Name = "Description")]
        public required string Description { get; set; }
    }
}
