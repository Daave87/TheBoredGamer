using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class PlayerNumberRepository : RepositoryBase<PlayerNumber>
    {
        public PlayerNumberRepository()
        {
            BsonClassMap.RegisterClassMap<PlayerNumber>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.PlayerNumberId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.UnmapProperty(x => x.BestVotes);
                cm.UnmapProperty(x => x.NotRecommendedVotes);
                cm.UnmapProperty(x => x.RecommendedVotes);
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<PlayerNumber>.IndexKeys.Ascending(x => x.Number).Descending(x => x.AndUp), new CreateIndexOptions { Unique = true });
        }
    }
}
