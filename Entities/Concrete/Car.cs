using Core.Entities;

namespace Entities.Concrete;

public class Car : Entity<int>
{
    //Id, ColorId, ModelId, CarState, Kilometer, ModelYear, Plate
    public int ColorId {  get; set; }
    public int ModelId { get; set; }
    public string CarState { get; set; }
    public float Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate {  get; set; }

    public Model? Model { get; set; } = null;
}
