namespace DBManager.DTOs.Components.Capacitors;

public class Capacitor_MLCC_SMD: Component, ICapacitor
{
    public required ComponentParameter<string> Footprint { get; init; }
    public required ComponentParameter<double> Capacitance { get; init; }
    public required ComponentParameter<string> Tolerance { get; init; }
    public required ComponentParameter<double> RatedVoltage { get; init; }
    public ComponentParameter<string>? TemperatureCoefficient { get; init; }

    public Capacitor_MLCC_SMD(Component? baseComponent = null)
    {
        //initialize the base component parameters, if a base component is provided
        if (baseComponent != null)
        {
            base.InitByInstance(baseComponent); 
        }
    }

    public void SetDefaultName()
    {
        SetName($"Capacitor MLCC SMD {Footprint} {Capacitance} {RatedVoltage} {Tolerance}");
    }
}