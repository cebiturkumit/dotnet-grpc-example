namespace DotnetGrpcClient.Models;

public class CategorySearchRequestModel
{
    public Guid? Id { get; set; }
    public Guid? ParentId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public string? SortDirection { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}