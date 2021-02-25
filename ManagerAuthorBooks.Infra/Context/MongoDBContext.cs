using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Infra.MongoSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Infra.Context
{
    public class MongoDBContext
    {
        //atributos
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase _database;
        

        //injecao de dependencia
        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;
            Initialize();
        }

        //metodo para inicializar uma conexão com o banco de dados
        private void Initialize()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.ConnectionString));

            if (_mongoDBSettings.IsSSL is true)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var client = new MongoClient(settings);
            _database = client.GetDatabase(_mongoDBSettings.DatabaseName);
        }

        //Configurar as Collections que serão criadas no mongodb
        public IMongoCollection<Author> Authors
        {
            get
            {
                return _database.GetCollection<Author>("Authors");
            }
        }

        public IMongoCollection<Books> Books
        {
            get
            {
                return _database.GetCollection<Books>("Books");
            }
        }
    }
}
