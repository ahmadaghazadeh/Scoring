namespace Scoring.Application.Contracts.Rules
{
    public class DefineRuleCommand
    {
        public string Title { get; set; }

        public bool IsIncreasing { get; set; }

        public required CriteriaData Criteria { get; set; }
    }

    public class CriteriaData
    {
    }
}
