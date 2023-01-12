namespace DotnetGrpcClient.Models;

public class CategoryResponseModel
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
}