using MongoDB.Driver;
using Scoring.Domain.Model.Rules;

namespace Scoring.Infrastructure.Persistence.Mongo
{
    public class MongoRuleRepository : IRuleRepository
    {
        private readonly IMongoDatabase _database;
        public MongoRuleRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public Task Add(Rule rule)
        { 
            var collection=_database.GetCollection<Rule>("Rules");
            return collection.InsertOneAsync(rule);
        }

        public Task<Rule> Get(Guid id)
        {
            var collection=_database.GetCollection<Rule>("Rules");
            return collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Rule>> GetActiveRules()
        {
            var collection = _database.GetCollection<Rule>("Rules");
            return collection.Find(x => x.IsActive == true).ToListAsync();
        }
    }
}