namespace Scoring.Application.Contracts
{
    public interface IRuleService 
    {
        int DefineRule();

        void DeactivateRule();

        void Activate();

    }
} 