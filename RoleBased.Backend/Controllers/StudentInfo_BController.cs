using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.StudentInfo.Command;
using RoleBased.Core.CQRS.StudentInfo.Query;
using RoleBased.Service.Model;

namespace RoleBased.Backend.Controllers;

public class StudentInfo_BController : APIController
{
    [HttpGet("Id:string")]
    public async Task<ActionResult<StudentInfo_VM>> GetStudentInfo(string Id)
    {
        return await HandleQueryAsync(new GetStudentInfoById(Id));
    }
    [HttpPost]
    public async Task<ActionResult<StudentInfo_VM>> InsertStudentInfo(StudentInfo_VM data)
    {
        return await HandleCommandAsync(new CreateStudentInfoCommand(data));
    }
}
