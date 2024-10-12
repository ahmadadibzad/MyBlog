using MyBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities;

public class Category : BaseEntity, IHasId, IHasDateTime, IHasTitle
{
	public required string Title { get; set; }
	public ICollection<Post>? Posts { get; set; }
}
