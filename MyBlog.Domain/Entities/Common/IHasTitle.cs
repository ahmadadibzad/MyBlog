using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain.Entities.Common;

public interface IHasTitle
{
	[Required(ErrorMessage = "Title required")]
	string Title { get; set; }
}
