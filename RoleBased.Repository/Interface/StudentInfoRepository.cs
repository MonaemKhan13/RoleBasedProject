using AutoMapper;
using RoleBased.Infractructure.Presistance;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;

namespace RoleBased.Repository.Interface;

public class StudentInfoRepository : RepositoryBase<StudentInfo_M, StudentInfo_VM, string>,IStudentInfoRepository
{
    public StudentInfoRepository(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {

    }
}
