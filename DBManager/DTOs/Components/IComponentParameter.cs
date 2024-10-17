namespace DBManager.DTOs.Components;

public interface IComponentParameter<T> where T: IConvertible
{
    T Value { get; }
    string ValueString { get; }
    string ToString();
    ComponentParameter<TResult> Cast<TResult>() where TResult : IConvertible;
}