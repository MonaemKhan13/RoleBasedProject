using RoleBased.Model;
using RoleBased.Service.Model;
using RoleBased.Shared.Contracts;

namespace RoleBased.Repository.Concrete;

public interface ILoginDbRepository : IRepository<LoginDb_M,LoginDb_VM,string>
{
}
