using GrpcProtos.Category;

namespace DotnetGrpcServer.Services;

public interface ICategoryService
{
    CategoryResponse Get(CategoryGetByIdRequest request);

    CategoryResponse Create(CategoryCreateRequest request);

    CategoryResponse Update(CategoryUpdateRequest request);

    DeleteResponse Delete(CategoryDeleteRequest request);

    CategorySearchResponse Search(CategorySearchRequest request);
}