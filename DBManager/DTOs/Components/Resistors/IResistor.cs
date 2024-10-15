namespace DBManager.DTOs.Components.Resistors;

public interface IResistor: IComponent
{
    string Footprint { get; init; }
    ComponentParameter<double> Resistance { get; init; }
    ComponentParameter<string> Tolerance { get; init; }
    ComponentParameter<double> Power { get; init; }
    ComponentParameter<string> TemperatureCoefficient { get; init; }
}