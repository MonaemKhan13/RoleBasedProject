using RoleBased.Shared;
using System.ComponentModel.DataAnnotations;

namespace RoleBased.Service.Model;

public class LoginDb_VM : IVM
{
    public string RegNo { get; set; }
    public string PassWord { get; set; }
    public string Role { get; set; }
}
