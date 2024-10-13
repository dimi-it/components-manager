using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network;

public interface IPartNetDTO
{
    public DistributorPartDbDTO ToDistributorPartDbDTO();
}