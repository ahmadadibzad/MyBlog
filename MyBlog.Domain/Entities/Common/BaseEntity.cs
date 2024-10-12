namespace MyBlog.Domain.Entities.Common;

public class BaseEntity : IHasId, IHasDateTime
{
	public int Id { get; set; }
	public DateTime CreationTime { get; set; }
	public DateTime ModificationTime { get; set; }
}
