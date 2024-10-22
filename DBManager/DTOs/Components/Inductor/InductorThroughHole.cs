namespace DBManager.DTOs.Components.Inductor;

public class InductorThroughHole: Component, IInductor
{
    public required ComponentParameter<string> Footprint { get; init; }
    public required ComponentParameter<double> Inductance { get; init; }
    public required ComponentParameter<string> Tolerance { get; init; }
    public required ComponentParameter<double> RatedCurrent { get; init; }
    public required ComponentParameter<double> DCResistance { get; init; }
    public ComponentParameter<double>? SaturationCurrent { get; init; }
    public ComponentParameter<double>? QFrequency { get; init; }
    public ComponentParameter<double>? FrequencySelfResonant { get; init; }
    public ComponentParameter<string>? Type { get; init; }
    public ComponentParameter<string>? Ratings { get; init; }
    public ComponentParameter<double>? WireDiameter { get; init; }

    public InductorThroughHole(Component? baseComponent = null)
    {
        //initialize the base component parameters, if a base component is provided
        if (baseComponent != null)
        {
            base.InitByInstance(baseComponent); 
        }
    }
    
    public void SetDefaultName()
    {
        SetName($"Inductor TH {Footprint} {Inductance} {Tolerance} {RatedCurrent} {DCResistance}");
    }
}