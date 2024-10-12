using System.Linq.Expressions;

namespace MyBlog.Infrastructure.Repositories.Common;

public interface IRepository<TEntity> where TEntity : class
{
	Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);
	Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression, string? includes);

	void Add(TEntity entity);

    void Update(TEntity entity);

	void Delete(TEntity entity);
}
