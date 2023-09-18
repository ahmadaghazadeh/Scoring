namespace Loan.Domain.Model
{
    public class Range<T> where T: IComparable<T>, IEquatable<T>
    {
        public T Minimum { get; private set; }
        public T Maximum { get; private set; }

        public Range(T minimum, T maximum)
        {
            
        }
    }
}
