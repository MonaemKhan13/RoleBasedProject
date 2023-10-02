using RoleBased.Shared;
using RoleBased.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class StudentInfo_M:BaseAuditableEntity,IEntity
{
    public string RegNo { get; set; }
    public string Name { get; set; }
    public string DoB { get; set; }
    public string phone { get; set; }
    public string Email { get; set; }
}
