namespace DBManager.DTOs.Components.Capacitors;

public class Capacitor_Electrolytic_SMD: Component, ICapacitor
{
    public required ComponentParameter<string> Footprint { get; init; }
    public required ComponentParameter<double> Capacitance { get; init; }
    public required ComponentParameter<string> Tolerance { get; init; }
    public required ComponentParameter<double> RatedVoltage { get; init; }
    public ComponentParameter<double>? Height { get; init; }
    public ComponentParameter<double>? Diameter { get; init; }
    public ComponentParameter<double>? ESR { get; init; }
    public ComponentParameter<double>? RippleCurrent { get; init; }
    public ComponentParameter<string>? OperatingTemperatureRange { get; init; }
    public ComponentParameter<double>? LifetimeTemperature { get; init; }
    

    public Capacitor_Electrolytic_SMD(Component? baseComponent = null)
    {
        //initialize the base component parameters, if a base component is provided
        if (baseComponent != null)
        {
            base.InitByInstance(baseComponent); 
        }
    }
    
    public void SetDefaultName()
    {
        SetName($"Capacitor Electrolytic SMD {Footprint} {Capacitance} {RatedVoltage} {Tolerance}");
    }
}