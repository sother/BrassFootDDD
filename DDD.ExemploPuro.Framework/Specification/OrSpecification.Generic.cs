
namespace DDD.ExemploPuro.Framework
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> spec1;
        private readonly ISpecification<T> spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        public override bool IsSatisfiedBy(T t)
        {
            return spec1.IsSatisfiedBy(t) || spec2.IsSatisfiedBy(t);
        }
    }
}