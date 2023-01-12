using DotnetGrpcClient.Models;
using DotnetGrpcClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGrpcClient.Controllers;

[ApiController]
[Route("/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<CategoryResponseModel> Get([FromRoute] Guid id)
    {
        var result = await _categoryService.Get(id);
        return result;
    }

    [HttpPost]
    public async Task<CategoryResponseModel> Post([FromBody] CategoryCreateRequestModel model)
    {
        var result = await _categoryService.Create(model);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<CategoryResponseModel> Put([FromRoute] Guid id, [FromBody] CategoryUpdateRequestModel model)
    {
        var result = await _categoryService.Update(id, model);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<CategoryDeleteResponseModel> Delete([FromRoute] Guid id)
    {
        var result = await _categoryService.Delete(id);
        return result;
    }

    [HttpGet]
    public async Task<CategorySearchResponseModel> Search([FromQuery] CategorySearchRequestModel model)
    {
        var result = await _categoryService.Search(model);
        return result;
    }
}