namespace DBManager.DTOs.Components;

public interface IComponentParameter<T> where T: IConvertible
{
    public T Value { get; init; }
    string ToString();
}