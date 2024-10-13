using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.DTOs;

public interface IPartNetDTO
{
    public DistributorPartDbDTO ToDistributorPartDbDTO();
}