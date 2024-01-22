namespace Business.Dtos.Model;

public class ModelListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Brand { get; set; } = null;
    public string? Fuel { get; set; } = null;
    public string? Transmission { get; set; } = null;
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
}
