using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.DAL
{
    public class GameRepository : RepositoryBase<Game>
    {
        public GameRepository()
        {
            BsonClassMap.RegisterClassMap<Game>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.GameId)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.UnmapProperty(x => x.Artists);
                cm.UnmapProperty(x => x.Categories);
                cm.UnmapProperty(x => x.Compilations);
                cm.UnmapProperty(x => x.Designers);
                cm.UnmapProperty(x => x.Expansions);
                cm.UnmapProperty(x => x.Families);
                cm.UnmapProperty(x => x.Integrations);
                cm.UnmapProperty(x => x.LanguageDependences);
                cm.UnmapProperty(x => x.Mechanics);
                cm.UnmapProperty(x => x.Publishers);
                cm.UnmapProperty(x => x.PlayerAges);
                cm.UnmapProperty(x => x.PlayerNumbers);
                cm.SetIgnoreExtraElements(true);
            });
            
            CreateIndex(Builders<Game>.IndexKeys.Ascending(x => x.BoardGameGeekId), new CreateIndexOptions { Unique = true });
        }
    }
}
