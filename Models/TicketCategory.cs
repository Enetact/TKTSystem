using System;
using System.ComponentModel.DataAnnotations;

namespace HotspotGamingTicketingSystem.Models
{
    public class TicketCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Updated Date")]
        [DataType(DataType.DateTime)]
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
