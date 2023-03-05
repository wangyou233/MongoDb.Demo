using System.Text.Json.Serialization;

namespace MgDbDemo.Dtos;

public class CreateBookDto
{
    public string BookName { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }

    public string Author { get; set; }

    [JsonIgnore]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public class UpdateBookDto : CreateBookDto
{
    public string Id { get; set; }

    [JsonIgnore]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}