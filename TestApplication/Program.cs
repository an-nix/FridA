// See https://aka.ms/new-console-template for more information
using DataAccess;
using Models.Recipe;

//mongodb://frida:@:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=

MongoOptions options = new MongoOptions
{
    Username = "frida",
    Password = "J0TKkYdyLBSATVlMjdCG3nPYH0zLNAAxx0gKMtZArJgMuVu5pqCiwatyg0swcCafj031lRJZDA8Bb1LyUYwZyw==",
    Hostname = "frida.mongo.cosmos.azure.com",
    Port = 10255,
    Ssl = true,
    RetryWrites = false,
    ReplicaSet = "globaldb",
    TimeMs = 120000,
    AppName = "@frida@"
};

DataAccess.MongoDB n = new DataAccess.MongoDB(options);

try
{
    var db = n.Client.GetDatabase("frida");
    var u = db.ListCollections();

    Recipe _r = new Recipe();

    _r.Description = new Dictionary<string, string>();
    _r.Description.Add(Models.Language.EN.ToString(), "Test Recipe");
    _r.Description.Add(Models.Language.ES.ToString(), "Testa de recetta de mierda");

    var col = db.GetCollection<IRecipe>("recipes");
    col.InsertOne(_r);

    Console.WriteLine("Hello, World!");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);  
}




