using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository()
        {
            BsonClassMap.RegisterClassMap<Category>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.CategoryId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<Category>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
