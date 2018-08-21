using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class IntegrationRepository : RepositoryBase<Integration>
    {
        public IntegrationRepository()
        {
            BsonClassMap.RegisterClassMap<Integration>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.IntegrationId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<Integration>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
