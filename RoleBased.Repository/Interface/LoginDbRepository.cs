using AutoMapper;
using RoleBased.Infractructure.Presistance;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;

namespace RoleBased.Repository.Interface;

public class LoginDbRepository:RepositoryBase<LoginDb_M,LoginDb_VM,string>,ILoginDbRepository
{
    public LoginDbRepository(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        
    }
}
