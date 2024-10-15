using DBManager.DTOs;

namespace ComponentsManager.Infrastructure.Network;

public interface IPartNetDTO
{
    public DistributorPartDbDTO TryToDistributorPartDbDTO();
}