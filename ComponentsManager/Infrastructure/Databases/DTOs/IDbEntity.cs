using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComponentsManager.Infrastructure.Databases.DTOs;

public interface IDbEntity
{
    string Id { get; }
}