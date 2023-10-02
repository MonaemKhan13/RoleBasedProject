using AutoMapper;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;

namespace RoleBased.Core.CQRS.LoginDb.Command;
public record CreateLoginDbCommand(LoginDb_VM _data) : IRequest<CommandResult<LoginDb_VM>>;

public class CreateLoginDbCommandHandler : IRequestHandler<CreateLoginDbCommand, CommandResult<LoginDb_VM>>
{
    private readonly ILoginDbRepository _Repository;
    private readonly IMapper _mapper;

    public CreateLoginDbCommandHandler(ILoginDbRepository Repository, IMapper mapper)
    {
        _Repository = Repository;
        _mapper = mapper;
    }
    public async Task<CommandResult<LoginDb_VM>> Handle(CreateLoginDbCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<LoginDb_M>(request._data);
        var result = await _Repository.InsertAsync(data);
        return result switch
        {
            null => new CommandResult<LoginDb_VM>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<LoginDb_VM>(result, CommandResultTypeEnum.Success)
        };
    }
}