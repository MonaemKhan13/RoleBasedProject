using System.ComponentModel.DataAnnotations;

namespace RoleBased.Frontend.Models;

public class StudentInfo_FM
{
    [Key]
    [Required]
    public string RegNo { get; set; }
    public string Name { get; set; }
    public string DoB { get; set; }
    public string phone { get; set; }
    public string Email { get; set; }
}
