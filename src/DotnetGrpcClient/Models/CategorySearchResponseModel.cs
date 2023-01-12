namespace DotnetGrpcClient.Models;

public class CategorySearchResponseModel
{
    public long TotalCount { get; set; }
    public List<CategoryResponseModel> Results { get; set; }
}