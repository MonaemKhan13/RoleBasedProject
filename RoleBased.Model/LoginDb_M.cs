using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class LoginDb_M : IEntity
{
    public string RegNo { get; set; }
    public string PassWord { get; set; }
    public string Role { get; set; }
}
