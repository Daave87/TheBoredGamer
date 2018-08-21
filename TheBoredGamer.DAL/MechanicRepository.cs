using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class MechanicRepository : RepositoryBase<Mechanic>
    {
        public MechanicRepository()
        {
            BsonClassMap.RegisterClassMap<Mechanic>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.MechanicId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<Mechanic>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
