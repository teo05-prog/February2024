namespace WebApi.Entities;

public class StorageRoom
{
    public int Id { get; set; }
    public string Location { get; set; }
    public Dimensions Dimensions { get; set; }
    public List<Box> Boxes { get; set; }
}