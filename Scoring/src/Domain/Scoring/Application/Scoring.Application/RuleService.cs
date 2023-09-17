using Scoring.Application.Contracts;
using Scoring.Domain.Model.Rules;

namespace Scoring.Application
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepository;

        public RuleService(IRuleRepository ruleRepository)
        {
            this._ruleRepository = ruleRepository;
        }
        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void DeactivateRule()
        {
            throw new NotImplementedException();
        }

        public int DefineRule()
        {
            throw new NotImplementedException();
        }
    }
} 