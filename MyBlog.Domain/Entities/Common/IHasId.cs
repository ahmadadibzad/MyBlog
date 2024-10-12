using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain.Entities.Common;

public interface IHasId
{
	[Key]
	int Id { get; set; }
}
