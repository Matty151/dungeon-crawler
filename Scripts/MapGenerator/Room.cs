using System.Collections.Generic;

namespace RogueLike.Scripts.MapGenerator;

public abstract class Room
{
    public List<Door> Doors { get; protected set; }
}
