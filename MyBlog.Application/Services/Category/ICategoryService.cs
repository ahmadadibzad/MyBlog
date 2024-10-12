using MyBlog.Application.DTOs.Category;

namespace MyBlog.Application.Services.Category;

public interface ICategoryService
{
    Task<IEnumerable<Domain.Entities.Category>> GetCategories();
}
