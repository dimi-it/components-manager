namespace DBManager.DTOs.Components.Resistors;

public interface IResistor: IComponent
{
    //TODO maybe make footprint and repository for it using composition
    //TODO maybe change footprint to a ComponentParameter to have a seamless use of the class
    string Footprint { get; }
    ComponentParameter<double> Resistance { get; }
    ComponentParameter<string> Tolerance { get; }
    ComponentParameter<double>? Power { get; }
    ComponentParameter<string>? TemperatureCoefficient { get; }
    void SetDefaultName();
}