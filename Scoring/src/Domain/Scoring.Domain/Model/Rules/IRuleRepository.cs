
namespace Scoring.Domain.Model.Rules
{
    public interface IRuleRepository
    {
        Task Add(Rule rule);
        Task<Rule> Get(Guid id);
        Task<List<Rule>> GetActiveRules();
    }
}