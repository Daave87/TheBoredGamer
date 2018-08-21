using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class ExpansionRepository : RepositoryBase<Expansion>
    {
        public ExpansionRepository()
        {
            BsonClassMap.RegisterClassMap<Expansion>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.ExpansionId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<Expansion>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
