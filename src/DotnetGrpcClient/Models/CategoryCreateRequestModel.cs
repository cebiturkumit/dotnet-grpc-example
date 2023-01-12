namespace DotnetGrpcClient.Models;

public class CategoryCreateRequestModel
{
    public string Title { get; set; }
    public Guid? ParentId { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}