using System.ComponentModel.DataAnnotations;

namespace HotspotGamingTicketingSystem.Models
{
    public class TicketPriority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Priority Name")]
        [StringLength(100, ErrorMessage = "Priority name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Priority Level")]
        public int Level { get; set; }
    }
}
