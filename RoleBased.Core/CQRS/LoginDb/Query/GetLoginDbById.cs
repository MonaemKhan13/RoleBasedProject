using MediatR;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;

namespace RoleBased.Core.CQRS.LoginDb.Query;
public record GetLoginDbById(string Id) : IRequest<QueryResult<LoginDb_VM>>;

public class GetLoginDbByIdHandler : IRequestHandler<GetLoginDbById, QueryResult<LoginDb_VM>>
{
    private readonly ILoginDbRepository _Repository;

    public GetLoginDbByIdHandler(ILoginDbRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<QueryResult<LoginDb_VM>> Handle(GetLoginDbById request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetByIdAsync(request.Id);
        return data switch
        {
            null => new QueryResult<LoginDb_VM>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<LoginDb_VM>(data, QueryResultTypeEnum.Success)
        };
    }
}