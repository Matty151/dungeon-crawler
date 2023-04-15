using System.Collections.Generic;

namespace RogueLike.Scripts.MapGenerator.Rooms;

public class SquareRoom : Room
{
    public SquareRoom()
    {
        this.Doors = new List<Door>()
        {
            new(this, 0),
            new(this, 1),
            new(this, 2),
            new(this, 3),
        };
    }
}
