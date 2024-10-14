﻿using MongoDB.Driver;

namespace ComponentsManager.Infrastructure.Databases.Repositories;

public class MongoConnection
{
    private readonly MongoClient _client;
    public IMongoDatabase Db { get; private init; }

    public MongoConnection(string connectionString, string dbName)
    {
        _client = new MongoClient(connectionString);
        Db = _client.GetDatabase(dbName);
    }
}