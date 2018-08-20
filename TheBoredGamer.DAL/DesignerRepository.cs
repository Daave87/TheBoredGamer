using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class DesignerRepository : RepositoryBase<Designer>
    {
        public DesignerRepository()
        {
            BsonClassMap.RegisterClassMap<Designer>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.DesignerId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<Designer>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
