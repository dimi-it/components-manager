namespace DBManager.DTOs.Components.Inductor;

public interface IInductor: IComponent
{
    ComponentParameter<string> Footprint { get; }
    ComponentParameter<double> Inductance { get; }
    ComponentParameter<string> Tolerance { get; }
    ComponentParameter<double> RatedCurrent { get; }
    ComponentParameter<double> DCResistance { get; }
    ComponentParameter<double>? SaturationCurrent { get; }
    ComponentParameter<double>? QFrequency { get; }
    ComponentParameter<double>? FrequencySelfResonant { get; }
    ComponentParameter<string>? Type { get; }
    ComponentParameter<string>? Ratings { get; }
    void SetDefaultName();
}