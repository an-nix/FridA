using System.Security.Authentication;
using System.Xml.Xsl;
using MongoDB.Driver;

namespace DataAccess
{

    public interface IMongoOptions
    {
        string? Username { get; set; }
        string? Password { get; set; }
        string? Hostname { get; set; }
        int Port { get; set; }
        bool Ssl { get; set; }  
        bool RetryWrites { get; set; }
        string? ReplicaSet { get; set; }
        long TimeMs { get; set; }
        string? AppName { get; set; }
    }

    public class MongoOptions : IMongoOptions
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Hostname { get; set; }

        public int Port { get; set; }
        public bool Ssl { get; set; }
        public bool RetryWrites { get; set; }
        public string? ReplicaSet { get; set; }
        public long TimeMs { get; set; }
        public string? AppName { get; set; }
    }

    public class MongoDB
    {

        private readonly IMongoOptions _options;
        private MongoClient _client;

        public MongoClient Client { get { return _client; } }

        public MongoDB(IMongoOptions options)
        {

            this._options = options;
   
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.GetConnectionString()));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            this._client = new MongoClient(settings);/**/
        }

        private string GetConnectionString()
        {
            string _baseUrl = @$"mongodb://{_options.Username}:{_options.Password}@{_options.Hostname}:{_options.Port}";
            string _parameter = $@"?ssl={_options.Ssl.ToString().ToLower()}&retrywrites={_options.RetryWrites.ToString().ToLower()}&replicaSet={_options.ReplicaSet}&maxIdleTimeMS={_options.TimeMs}&appName={_options.AppName}";

            string connString = $"{_baseUrl}/{_parameter}";

            return connString;
        }



    }
}