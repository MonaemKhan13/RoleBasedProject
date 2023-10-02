namespace RoleBased.Shared.Models;

public enum CommandResultTypeEnum
{
    Success,
    Created = 201,
    InvalidInput = 400,
    UnprocessableEntity = 500,
    Confict,
    NotFound = 404,
    UnAuthorized = 401
}
