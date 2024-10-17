namespace DBManager.DTOs.Components;

public class ComponentParameter<T> : IComponentParameter<T> where T: IConvertible
{
    public T Value { get; }
    public string ValueString { get; }

    public ComponentParameter(T value, string? valueString = null)
    {
        Value = value ?? throw new InvalidOperationException($"The component parameter \"value\" cannot be null!");
        ValueString = valueString ?? value.ToString()!;
    }

    public ComponentParameter<TResult> Cast<TResult>() where TResult: IConvertible
    {
        return new ComponentParameter<TResult>((TResult)(object)Value, ValueString);
    }

    public override string ToString()
    {
        return ValueString;
    }
}