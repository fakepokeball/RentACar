using Core.Entities;

namespace Entities.Concrete;

public class Transmission : Entity<int>
{
    public string Name { get; set; }
    public int ModelId { get; set; }

    //public Model? Model { get; set; } = null;
}
