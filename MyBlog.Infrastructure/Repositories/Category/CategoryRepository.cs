using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Repositories.Common;

namespace MyBlog.Infrastructure.Repositories.Category;

public class CategoryRepository : Repository<Domain.Entities.Category>, ICategoryRepository
{
	public CategoryRepository(MyBlogDbContext myBlogDbContext) : base(myBlogDbContext)
	{
	}
}
