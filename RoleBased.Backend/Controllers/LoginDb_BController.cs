using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.LoginDb.Command;
using RoleBased.Core.CQRS.LoginDb.Query;
using RoleBased.Core.CQRS.StudentInfo.Command;
using RoleBased.Core.CQRS.StudentInfo.Query;
using RoleBased.Service.Model;

namespace RoleBased.Backend.Controllers;

public class LoginDb_BController : APIController
{
    [HttpGet("Id:string")]
    public async Task<ActionResult<StudentInfo_VM>> GetLoginDb(string Id)
    {
        return await HandleQueryAsync(new GetLoginDbById(Id));
    }
    [HttpPost]
    public async Task<ActionResult<StudentInfo_VM>> InsertLoginDb(LoginDb_VM data)
    {
        return await HandleCommandAsync(new CreateLoginDbCommand(data));
    }
}
