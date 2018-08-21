using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class CompilationRepository : RepositoryBase<Compilation>
    {
        public CompilationRepository()
        {
            BsonClassMap.RegisterClassMap<Compilation>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.CompilationId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            CreateIndex(Builders<Compilation>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
