using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Repositories.Common;

namespace MyBlog.Infrastructure.Repositories.Post;

public class PostRepository : Repository<Domain.Entities.Post>, IPostRepository
{
    public PostRepository(MyBlogDbContext myBlogDbContext) : base(myBlogDbContext)
    {
    }
}
