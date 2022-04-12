using MongoDB.Driver;

namespace proje.data.Concrete.EfCore
{
    public class MongoDbVerim
    {
        
MongoClient client ;

        public MongoDbVerim()
        {
            client= new MongoClient("mongodb+srv://galimuna:Alakrum85i@denemecluster.0nawm.mongodb.net/Test?retryWrites=true&w=majority");
        }
    }
}