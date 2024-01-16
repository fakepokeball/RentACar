namespace Business.Responses.Fuel;

public class AddFuelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public AddFuelResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }

}
