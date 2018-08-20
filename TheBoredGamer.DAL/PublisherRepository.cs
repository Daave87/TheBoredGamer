using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class PublisherRepository : RepositoryBase<Publisher>
    {
        public PublisherRepository()
        {
            BsonClassMap.RegisterClassMap<Publisher>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.PublisherId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<Publisher>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
