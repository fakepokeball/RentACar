namespace Business.Requests.Model;

public class AddModelRequest
{
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public short Year { get; set; }

    public AddModelRequest(string name, decimal dailyPrice, short year)
    {
        Name = name;
        DailyPrice = dailyPrice;
        Year = year;
    }
}
