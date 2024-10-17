using DBManager.DTOs;

namespace DistributorManager.DTOs;

public interface IPartDTO
{
    public DistributorPartDbDTO TryToDistributorPartDbDTO();
}