using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Infra.MongoSettings
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
