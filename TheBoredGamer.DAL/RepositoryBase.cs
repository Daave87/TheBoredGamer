using System;
using System.Collections.Generic;
using System.Security.Authentication;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TheBoredGamer.DAL
{
    public class RepositoryBase<T> : IDisposable
    {
        private bool _disposed;

        private const string UserName = "theboredgamerdb";
        private const string Host = "theboredgamerdb.documents.azure.com";
        private const string Password = "uvSw6KAzaaQ05o0IwSHAUhTGjfrOus9IX6TM1aZgjbfBxDHXIQ6yyFGAOVREOivZTWTbNTdm96WvCvzzuaKo3Q==";

        private static readonly string DatabaseName = typeof(T).Name;
        private static readonly string CollectionName = typeof(T).Name + "List";

        public List<T> GetAllItems()
        {
            try
            {
                var collection = GetItemCollection();

                return collection.Find(new BsonDocument()).ToList();
            }
            catch (MongoConnectionException)
            {
                return new List<T>();
            }
        }

        public void InsertOne(T item)
        {
            var collection = GetItemCollection();

            try
            {
                collection.InsertOne(item);
            }
            catch (MongoCommandException ex)
            {
                var msg = ex.Message;
            }
        }

        private static IMongoCollection<T> GetItemCollection()
        {
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(Host, 10255),
                UseSsl = true,
                SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 }
            };

            MongoIdentity identity = new MongoInternalIdentity(DatabaseName, UserName);
            MongoIdentityEvidence evidence = new PasswordEvidence(Password);

            settings.Credentials = new List<MongoCredential> { new MongoCredential("SCRAM-SHA-1", identity, evidence) };

            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseName);
            return database.GetCollection<T>(CollectionName);
        }
        
        public void CreateIndex(IndexKeysDefinition<T> indexKeysDefinition, CreateIndexOptions createIndexOptions)
        {
            var collection = GetItemCollection();

            collection.Indexes.CreateOne(indexKeysDefinition, createIndexOptions);
        }

        # region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }
            }

            _disposed = true;
        }

        # endregion
    }
}
