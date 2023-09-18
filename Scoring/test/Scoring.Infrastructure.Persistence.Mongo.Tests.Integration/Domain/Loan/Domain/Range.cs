using Loan.Domain.Model;

namespace Scoring.Infrastructure.Persistence.Mongo.Tests.Integration.Domain.Loan.Domain
{
    public class RangeTests
    {
        [Fact]
        public void MinimumValueIsSmallerThanMaximumValue()
        {
            Action actual = () => new Range<int>(11, 10);

            actual.
        }
    }
}
