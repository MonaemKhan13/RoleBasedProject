using System.ComponentModel.DataAnnotations;

namespace RoleBased.Frontend.Models;

public class LoginDb_FM
{
    [Key]
    [Required]
    public string RegNo { get; set; }

    [Required]
    [StringLength(maximumLength: 10, MinimumLength = 6)]
    public string PassWord { get; set; }
    public string? Role { get; set; }
}
