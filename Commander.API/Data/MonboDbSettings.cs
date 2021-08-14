namespace Commander.API.Data
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host {get; set;}
        public string Port { get; set; }
        public string ConnectionString
        {
            get
            {
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }


    }
}