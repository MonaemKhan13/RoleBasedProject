namespace RoleBased.Shared.Models;

public class CommandResult<T>
{
    public CommandResult(T? result, CommandResultTypeEnum type)
    {
        Result = result;
        Type = type;
    }
    public T? Result { get; set; }
    public CommandResultTypeEnum Type { get; set; }
}
