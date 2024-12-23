using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotspotGamingTicketingSystem.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string? FileName { get; set; }

        [Required]
        [Display(Name = "File Path")]
        public string? FilePath { get; set; }

        [Required]
        [Display(Name = "Content Type")]
        public string? ContentType { get; set; }

        [Required]
        [Display(Name = "File Size (Bytes)")]
        public long FileSize { get; set; }

        [Display(Name = "Uploaded On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        // Assuming each attachment is related to one ticket
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }
    }
}
