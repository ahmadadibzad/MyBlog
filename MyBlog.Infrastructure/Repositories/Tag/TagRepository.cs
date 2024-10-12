using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Repositories.Common;

namespace MyBlog.Infrastructure.Repositories.Tag;

public class TagRepository : Repository<Domain.Entities.Tag>, ITagRepository
{
	public TagRepository(MyBlogDbContext myBlogDbContext) : base(myBlogDbContext)
	{
	}
}
