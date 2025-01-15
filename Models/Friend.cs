using System.ComponentModel.DataAnnotations;

public class Friend{
    [Key]
    [Required]
    public Guid FriendId {get; set;}
    [Required(ErrorMessage ="Friend name empty not allowed.")]
    [StringLength(25, ErrorMessage = "Friend name empty not allowed.")]
    public string? FriendName {get; set;}
    [StringLength(25, ErrorMessage = "Max length is 25 Characters")]
    public string? Place {get; set;}
}