using System.ComponentModel.DataAnnotations;

public class Friend{
    [Key]
    [Required]
    public Guid FriendId {get; set;}
    [Required]
    [StringLength(25, ErrorMessage = "Friend name empty not allowed.")]
    public string? FriendName {get; set;}
    public string? Place {get; set;}
}