
namespace DDD.ExemploPuro.Framework
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> spec1;

        public NotSpecification(ISpecification<T> spec1)
        {
            this.spec1 = spec1;
        }

        public override bool IsSatisfiedBy(T t)
        {
            return !spec1.IsSatisfiedBy(t);
        }
    }
}