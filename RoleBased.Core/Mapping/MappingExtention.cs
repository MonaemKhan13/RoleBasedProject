using AutoMapper;
using RoleBased.Model;
using RoleBased.Service.Model;

namespace RoleBased.Core.Mapping;
public class MappingExtention : Profile
{
    public MappingExtention()
    {
        CreateMap<StudentInfo_VM, StudentInfo_M>().ReverseMap();
        CreateMap<LoginDb_VM, LoginDb_M>().ReverseMap();
    }
}
