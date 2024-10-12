using Microsoft.AspNetCore.Identity;

namespace MyBlog.Domain.Entities;

public class BlogUser : IdentityUser
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}
