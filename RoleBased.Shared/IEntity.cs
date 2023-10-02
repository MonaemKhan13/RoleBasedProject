namespace RoleBased.Shared;
public interface IEntity<T> where T : IEquatable<T>
{
    T RegNo { get; set; }
}
public interface IEntity : IEntity<string> { }
