using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Repositories.Category;
using MyBlog.Infrastructure.Repositories.Post;
using MyBlog.Infrastructure.Repositories.Tag;

namespace MyBlog.Infrastructure.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyBlogDbContext _dbContext;

    public ICategoryRepository CategoryRepository { get; private set; }
    public IPostRepository PostRepository { get; private set; }
    public ITagRepository TagRepository { get; private set; }

	public UnitOfWork(MyBlogDbContext myBlogDbContext)
    {
        _dbContext = myBlogDbContext;
        CategoryRepository = new CategoryRepository(_dbContext);
        PostRepository = new PostRepository(_dbContext);
        TagRepository = new TagRepository(_dbContext);
	}

    public void Save()
	{
		_dbContext.SaveChanges();
	}
}
