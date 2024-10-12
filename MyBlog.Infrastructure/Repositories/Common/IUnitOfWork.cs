using MyBlog.Infrastructure.Repositories.Category;
using MyBlog.Infrastructure.Repositories.Post;
using MyBlog.Infrastructure.Repositories.Tag;

namespace MyBlog.Infrastructure.Repositories.Common;

public interface IUnitOfWork
{
	ICategoryRepository CategoryRepository { get; }
	IPostRepository PostRepository { get; }
	ITagRepository TagRepository { get; }
	void Save();
}
