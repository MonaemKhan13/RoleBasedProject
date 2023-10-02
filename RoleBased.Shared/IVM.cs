namespace RoleBased.Shared;

public interface IVM<T> where T : IEquatable<T>
{
    T RegNo { get; set; }
}

public interface IVM : IVM<string> { }
