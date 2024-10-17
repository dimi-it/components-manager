namespace DBManager.DTOs.Components.Resistors;

public class Resistor_SMD: Component, IResistor
{
    public required ComponentParameter<string> Footprint { get; init; }
    public required ComponentParameter<double> Resistance { get; init; }
    public required ComponentParameter<string> Tolerance { get; init; }     
    public ComponentParameter<double>? Power { get; init; }                      
    public ComponentParameter<string>? TemperatureCoefficient { get; init; }
    public ComponentParameter<string>? Type { get; init; }                       
    public ComponentParameter<double>? OverloadVoltage { get; init; }                        
    public ComponentParameter<string>? OperatingTemperatureRange { get; init; }
    
    public Resistor_SMD(Component? baseComponent = null)
    {
        //initialize the base component parameters, if a base component is provided
        if (baseComponent != null)
        {
            base.InitByInstance(baseComponent); 
        }
    }

    public void SetDefaultName()
    {
        SetName($"Resistor SMD {Footprint} {Resistance} {Tolerance}");
    }
}