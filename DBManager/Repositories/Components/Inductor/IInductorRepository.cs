using DBManager.DTOs.Components.Inductor;

namespace DBManager.Repositories.Components.Inductor;

public interface IInductorRepository<T> where T: IInductor
{
    Task<IEnumerable<T>> GetByFootprintAsync(string footprint);
    Task<IEnumerable<T>> GetByInductanceAsync(double inductance);
    Task<IEnumerable<T>> GetByToleranceAsync(string tolerance);
    Task<IEnumerable<T>> GetByRatedCurrentAsync(double ratedCurrent);
    Task<IEnumerable<T>> GetByDCResistanceAsync(double dcResistance);
}