using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Data;

public class MyBlogDbContext : IdentityDbContext<BlogUser>
{
    public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<BlogUser> BlogUsers { get; set; }
}
