using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class ArtistRepository : RepositoryBase<Artist>
    {
        public ArtistRepository()
        {
            BsonClassMap.RegisterClassMap<Artist>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.ArtistId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<Artist>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
