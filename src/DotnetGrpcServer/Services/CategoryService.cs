using GrpcProtos.Category;

namespace DotnetGrpcServer.Services;

public class CategoryService : ICategoryService
{
    public CategoryResponse Get(CategoryGetByIdRequest request)
    {
        return new CategoryResponse
        {
            Id = Guid.NewGuid().ToString(),
            Title = "TEST",
            Description = "TEST",
            ImagePath = "/test/image/path/asd.png",
        };
    }

    public CategoryResponse Create(CategoryCreateRequest request)
    {
        return new CategoryResponse
        {
            Id = Guid.NewGuid().ToString(),
            Title = request.Title,
            Description = request.Description,
            ImagePath = request.ImagePath,
            ParentId = request.ParentId
        };
    }

    public CategoryResponse Update(CategoryUpdateRequest request)
    {
        return new CategoryResponse
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            ImagePath = request.ImagePath,
            ParentId = request.ParentId
        };
    }

    public DeleteResponse Delete(CategoryDeleteRequest request)
    {
        return new DeleteResponse
        {
            IsDeleted = true
        };
    }

    public CategorySearchResponse Search(CategorySearchRequest request)
    {
        var response = new CategorySearchResponse {TotalCount = 1};
        response.Results.Add(Get(new CategoryGetByIdRequest {Id = Guid.NewGuid().ToString()}));

        return response;
    }
}