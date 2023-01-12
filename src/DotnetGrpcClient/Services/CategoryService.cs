using DotnetGrpcClient.Models;
using GrpcProtos.Category;

namespace DotnetGrpcClient.Services;

public class CategoryService : ICategoryService
{
    private readonly GrpcProtos.Category.CategoryService.CategoryServiceClient _categoryServiceClient;

    public CategoryService(GrpcProtos.Category.CategoryService.CategoryServiceClient categoryServiceClient)
    {
        _categoryServiceClient = categoryServiceClient;
    }

    public async Task<CategoryResponseModel> Get(Guid id)
    {
        var request = new CategoryGetByIdRequest {Id = id.ToString()};
        var response = await _categoryServiceClient.getByIdAsync(request);
        var responseModel = CategoryResponseToModel(response);

        return responseModel;
    }

    public async Task<CategoryResponseModel> Create(CategoryCreateRequestModel model)
    {
        var request = new CategoryCreateRequest
        {
            Title = model.Title,
            Description = model.Description,
            ImagePath = model.ImagePath,
            ParentId = model.ParentId?.ToString() ?? ""
        };
        var response = await _categoryServiceClient.createAsync(request);
        var responseModel = CategoryResponseToModel(response);

        return responseModel;
    }

    public async Task<CategoryResponseModel> Update(Guid id, CategoryUpdateRequestModel model)
    {
        var request = new CategoryUpdateRequest
        {
            Id = id.ToString(),
            Title = model.Title,
            Description = model.Description,
            ImagePath = model.ImagePath,
            ParentId = model.ParentId?.ToString() ?? ""
        };
        var response = await _categoryServiceClient.updateAsync(request);
        var responseModel = CategoryResponseToModel(response);

        return responseModel;
    }

    public async Task<CategoryDeleteResponseModel> Delete(Guid id)
    {
        var request = new CategoryDeleteRequest {Id = id.ToString()};
        var response = await _categoryServiceClient.deleteAsync(request);
        var responseModel = new CategoryDeleteResponseModel {IsDeleted = response.IsDeleted};

        return responseModel;
    }

    public async Task<CategorySearchResponseModel> Search(CategorySearchRequestModel model)
    {
        var request = new CategorySearchRequest
        {
            Id = model.Id?.ToString() ?? "",
            ParentId = model.ParentId?.ToString() ?? "",
            Title = model.Title ?? "",
            Description = model.Description ?? "",
            ImagePath = model.ImagePath ?? "",
            SortDirection = model.SortDirection ?? "",
            Page = model.Page,
            Size = model.Size
        };
        var response = await _categoryServiceClient.searchAsync(request);
        var responseModel = new CategorySearchResponseModel
        {
            TotalCount = response.TotalCount,
            Results = response.Results.Select(CategoryResponseToModel).ToList()
        };

        return responseModel;
    }

    private static CategoryResponseModel CategoryResponseToModel(CategoryResponse response)
    {
        return new CategoryResponseModel
        {
            Id = Guid.Parse(response.Id),
            Title = response.Title,
            Description = response.Description,
            ImagePath = response.ImagePath,
            ParentId = string.IsNullOrEmpty(response.ParentId) ? null : Guid.Parse(response.ParentId)
        };
    }
}