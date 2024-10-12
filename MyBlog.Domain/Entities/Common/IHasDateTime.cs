namespace MyBlog.Domain.Entities.Common;

public interface IHasDateTime
{
	DateTime CreationTime { get; set; }
	DateTime ModificationTime { get; set; }
}
