using Framework.Persistence.Mongo;
using MongoDB.Driver;
using Scoring.Domain.Model.Rules;

namespace Scoring.Infrastructure.Persistence.Mongo
{
    public class MongoRuleRepository : MongoRepository<Rule, Guid>, IRuleRepository
    {

        public MongoRuleRepository(IMongoDatabase database) : base(database) { }

        public Task Add(Rule rule)
        { 
            return AggregateCollection.InsertOneAsync(rule);
        }

        public Task<Rule> Get(Guid id)
        {
            return AggregateCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Rule>> GetActiveRules()
        {
            return AggregateCollection.Find(x => x.IsActive == true).ToListAsync();
        }
    }
}