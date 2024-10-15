namespace DBManager.DTOs.Components;

public class ComponentParameter<T> : IComponentParameter<T> where T: IConvertible
{
    public T Value { get; init; }
    private readonly string _valueString;

    public ComponentParameter(T value, string? valueString = null)
    {
        Value = value ?? throw new InvalidOperationException($"The component parameter \"value\" cannot be null!");
        _valueString = valueString ?? value.ToString()!;
    }

    public override string ToString()
    {
        return _valueString;
    }
}