namespace Business.Responses.Transmission;

public class AddTransmissionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public AddTransmissionResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
