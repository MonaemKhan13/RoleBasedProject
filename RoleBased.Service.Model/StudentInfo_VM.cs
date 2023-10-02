using RoleBased.Shared;

namespace RoleBased.Service.Model;

public class StudentInfo_VM : IVM
{
    public string RegNo { get; set; }
    public string Name { get; set; }
    public string DoB { get; set; }
    public string phone { get; set; }
    public string Email { get; set; }
}
