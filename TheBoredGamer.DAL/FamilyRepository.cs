using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class FamilyRepository : RepositoryBase<Family>
    {
        public FamilyRepository()
        {
            BsonClassMap.RegisterClassMap<Family>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.FamilyId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<Family>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
