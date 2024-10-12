using MyBlog.Infrastructure.Repositories.Common;

namespace MyBlog.Application.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Category>> GetCategories()
    {
        return await _unitOfWork.CategoryRepository.GetAll(null, null);
    }
}
