using System.ComponentModel.DataAnnotations.Schema;

public class Device
{
    public int DeviceId { get; set; }  // Primary key
    public virtual DirectoryObject? DirectoryObject { get; set; }  // Navigation property
}

public class DirectoryObject
{
    public int DirectoryObjectId { get; set; }  // Primary key
    public int DeviceId { get; set; }  // Foreign key
    [ForeignKey("DeviceId")]
    public virtual Device? Device { get; set; }  // Navigation property
}
