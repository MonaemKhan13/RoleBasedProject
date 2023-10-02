using AutoMapper;
using RoleBased.Infractructure.Presistance;
using RoleBased.Model;
using RoleBased.Service.Model;
using RoleBased.Shared.Contracts;

namespace RoleBased.Repository.Concrete;

public interface IStudentInfoRepository : IRepository<StudentInfo_M, StudentInfo_VM, string>
{

}