using DotnetGrpcServer.Services;
using Grpc.Core;
using GrpcProtos.Category;

namespace DotnetGrpcServer.Servers;

public class CategoryServer : GrpcProtos.Category.CategoryService.CategoryServiceBase
{
    private readonly ICategoryService _categoryService;

    public CategoryServer(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override Task<CategoryResponse> create(CategoryCreateRequest request, ServerCallContext context)
    {
        var response = _categoryService.Create(request);
        return Task.FromResult(response);
    }

    public override Task<CategoryResponse> update(CategoryUpdateRequest request, ServerCallContext context)
    {
        var response = _categoryService.Update(request);
        return Task.FromResult(response);
    }

    public override Task<DeleteResponse> delete(CategoryDeleteRequest request, ServerCallContext context)
    {
        var response = _categoryService.Delete(request);
        return Task.FromResult(response);
    }

    public override Task<CategoryResponse> getById(CategoryGetByIdRequest request, ServerCallContext context)
    {
        var response = _categoryService.Get(request);
        return Task.FromResult(response);
    }

    public override Task<CategorySearchResponse> search(CategorySearchRequest request, ServerCallContext context)
    {
        var response = _categoryService.Search(request);
        return Task.FromResult(response);
    }
}