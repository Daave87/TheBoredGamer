using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class PlayerAgeRepository : RepositoryBase<PlayerAge>
    {
        public PlayerAgeRepository()
        {
            BsonClassMap.RegisterClassMap<PlayerAge>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.PlayerAgeId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.UnmapProperty(x => x.Votes);
            });
            
            CreateIndex(Builders<PlayerAge>.IndexKeys.Ascending(x => x.Age).Descending(x => x.AndUp), new CreateIndexOptions { Unique = true });
        }
    }
}
