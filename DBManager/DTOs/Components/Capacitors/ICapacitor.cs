namespace DBManager.DTOs.Components.Capacitors;

public interface ICapacitor: IComponent
{
    ComponentParameter<string> Footprint { get; }
    ComponentParameter<double> Capacitance { get; }
    ComponentParameter<string> Tolerance { get; }
    ComponentParameter<double> RatedVoltage { get; }
    void SetDefaultName();
}