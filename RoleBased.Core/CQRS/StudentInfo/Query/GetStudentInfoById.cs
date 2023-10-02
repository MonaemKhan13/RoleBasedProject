using MediatR;
using RoleBased.Repository.Concrete;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;

namespace RoleBased.Core.CQRS.StudentInfo.Query;
public record GetStudentInfoById(string Id) : IRequest<QueryResult<StudentInfo_VM>>;

public class GetStudentInfoByIdHandler : IRequestHandler<GetStudentInfoById, QueryResult<StudentInfo_VM>>
{
    private readonly IStudentInfoRepository _Repository;

    public GetStudentInfoByIdHandler(IStudentInfoRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<QueryResult<StudentInfo_VM>> Handle(GetStudentInfoById request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetByIdAsync(request.Id);
        return data switch
        {
            null => new QueryResult<StudentInfo_VM>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<StudentInfo_VM>(data, QueryResultTypeEnum.Success)
        };
    }
}