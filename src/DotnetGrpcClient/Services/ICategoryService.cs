using DotnetGrpcClient.Models;

namespace DotnetGrpcClient.Services;

public interface ICategoryService
{
    Task<CategoryResponseModel> Get(Guid id);

    Task<CategoryResponseModel> Create(CategoryCreateRequestModel model);

    Task<CategoryResponseModel> Update(Guid id, CategoryUpdateRequestModel model);

    Task<CategoryDeleteResponseModel> Delete(Guid id);

    Task<CategorySearchResponseModel> Search(CategorySearchRequestModel model);
}