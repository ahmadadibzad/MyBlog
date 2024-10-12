using MyBlog.Domain.Entities.Common;

namespace MyBlog.Domain.Entities;

public class Tag : BaseEntity, IHasId, IHasDateTime, IHasTitle
{
	public required string Title { get; set; }
	public ICollection<Post>? Posts { get; set; }
}
