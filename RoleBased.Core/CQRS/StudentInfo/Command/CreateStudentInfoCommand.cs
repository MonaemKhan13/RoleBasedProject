using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.StudentInfo.Command;

public record CreateStudentInfoCommand(StudentInfo_VM _data) : IRequest<CommandResult<StudentInfo_VM>>;

public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, CommandResult<StudentInfo_VM>>
{
    private readonly IStudentInfoRepository _Repository;
    private readonly IMapper _mapper;

    public CreateStudentInfoCommandHandler(IStudentInfoRepository Repository, IMapper mapper)
    {
        _Repository = Repository;
        _mapper = mapper;
    }
    public async Task<CommandResult<StudentInfo_VM>> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<StudentInfo_M>(request._data);
        var result = await _Repository.InsertAsync(data);
        return result switch
        {
            null => new CommandResult<StudentInfo_VM>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<StudentInfo_VM>(result, CommandResultTypeEnum.Success)
        };
    }
}