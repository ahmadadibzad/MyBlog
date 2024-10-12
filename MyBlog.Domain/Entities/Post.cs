using MyBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities;

public class Post : BaseEntity, IHasTitle
{
	public required string Title { get; set; }
	public string? Content { get; set; }
	public string? Url { get; set; }
	public string? ImgUrl { get; set; }
    public Category Category { get; set; }
	[ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
	public ICollection<Tag>? Tags { get; set; }
}
