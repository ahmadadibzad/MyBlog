using Microsoft.EntityFrameworkCore;
using MyBlog.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyBlog.Infrastructure.Repositories.Common;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly MyBlogDbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public Repository(MyBlogDbContext myBlogDbContext)
    {
        _dbContext = myBlogDbContext;
		_dbSet = _dbContext.Set<TEntity>();
    }

    public async void Add(TEntity entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public void Delete(TEntity entity)
	{
		_dbSet.Remove(entity);
	}

	public void Update(TEntity entity)
	{
		_dbSet.Update(entity);
	}

	public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, string includes)
	{
		IQueryable<TEntity> query = _dbSet;

        if (expression is not null)
        {
			query = query.Where(expression);
        }

		if (!string.IsNullOrEmpty(includes))
		{
            foreach (var item in includes.Split(','))
            {
				query = query.Include(item);
            }
        }

		return await query.ToListAsync();
    }

	public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
	{

		IQueryable<TEntity> query = _dbSet;
		return await query.FirstOrDefaultAsync(expression);
	}
}
