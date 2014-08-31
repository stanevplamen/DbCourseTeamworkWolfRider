using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;


namespace Providers.Data
{
    public static class MongoDbProvider
    {
        public static MongoDatabase db
        {
            get
            {
                var connectionstring = dbSetting.Default.MONGOLAB_URI;
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }

        public static void SaveData<T>(this MongoDatabase source, T value)
        {
            try
            {
                var result = db.GetCollection<T>(typeof(T).Name).Save(value, SafeMode.True);
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }
    }
}
