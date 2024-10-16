namespace DBManager.DTOs.Components.Resistors;

public interface IResistor: IComponent
{
    //TODO maybe make footprint and repository for it using composition
    string Footprint { get; init; }
    ComponentParameter<double> Resistance { get; init; }
    ComponentParameter<string>? Tolerance { get; init; }
    ComponentParameter<double>? Power { get; init; }
    ComponentParameter<string>? TemperatureCoefficient { get; init; }
}