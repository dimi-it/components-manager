using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network.DTOs;

public interface IResultNetDTO
{
    public IPartDbDTO ToPartDbDTO();
}