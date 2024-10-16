using DBManager.DTOs.Components;
using DBManager.DTOs.Components.Resistors;

namespace DBManager.Repositories.Components.Resistor;

public interface IResistorRepository<T> where T: IResistor
{
    Task<IEnumerable<T>> GetByFootprintAsync(string footprint);
    Task<IEnumerable<T>> GetByResistanceAsync(double resistance);
    Task<IEnumerable<T>> GetByToleranceAsync(string tolerance);
}