using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class LanguageDependenceRepository : RepositoryBase<LanguageDependence>
    {
        public LanguageDependenceRepository()
        {
            BsonClassMap.RegisterClassMap<LanguageDependence>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.LanguageDependenceId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.UnmapProperty(x => x.Votes);
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<LanguageDependence>.IndexKeys.Ascending(x => x.Description), new CreateIndexOptions { Unique = true });
        }
    }
}
