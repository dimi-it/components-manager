namespace DBManager.DTOs.Components;

public class ComponentParameter<T> : IComponentParameter<T> where T: IConvertible
{
    public T Value { get; private init; }
    public string ValueString { get; private init; }

    public ComponentParameter(T value, string? valueString = null)
    {
        Value = value ?? throw new InvalidOperationException($"The component parameter \"value\" cannot be null!");
        ValueString = valueString ?? value.ToString()!;
    }

    public override string ToString()
    {
        return ValueString;
    }
}