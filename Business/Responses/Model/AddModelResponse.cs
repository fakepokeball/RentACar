namespace Business.Responses.Model;

public class AddModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public AddModelResponse(int id, string name, decimal dailyPrice)
    {
        Id = id;
        Name = name;
        DailyPrice = dailyPrice;
    }
}
