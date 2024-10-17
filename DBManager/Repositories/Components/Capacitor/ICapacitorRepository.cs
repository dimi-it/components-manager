using DBManager.DTOs.Components.Capacitors;

namespace DBManager.Repositories.Components.Capacitor;

public interface ICapacitorRepository<T> where T: ICapacitor
{
    Task<IEnumerable<T>> GetByFootprintAsync(string footprint);
    Task<IEnumerable<T>> GetByCapacitanceAsync(double capacitance);
    Task<IEnumerable<T>> GetByToleranceAsync(string tolerance);
    Task<IEnumerable<T>> GetByRatedVoltageAsync(double ratedVoltage);

}