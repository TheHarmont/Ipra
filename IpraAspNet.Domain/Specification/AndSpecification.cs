using System.Linq.Expressions;


namespace IpraAspNet.Domain.Specification;

public class AndSpecification<T, TResult>(Specification<T> left, Specification<T> right): Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.AndAlso(
            Expression.Invoke(leftExpression, parameter),
            Expression.Invoke(rightExpression, parameter)
        );
        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }
}