using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.Repositories.Common;

namespace MyBlog.Infrastructure.Repositories.Post;

public interface IPostRepository : IRepository<Domain.Entities.Post>
{
}
