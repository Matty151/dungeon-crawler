using System.Collections.Generic;
using Godot;

namespace RogueLike.Scripts.MapGenerator.Rooms;

public class SquareRoom : Room
{
    public SquareRoom(Vector2I gridPosition) : base(gridPosition)
    {
        this.Doors = new List<Door>()
        {
            new(this, new Vector2(0, -0.5f)), // Top
            new(this, new Vector2(0.5f, 0)), // Right
            new(this, new Vector2(0, 0.5f)), // Bottom
            new(this, new Vector2(-0.5f, 0)), // Left
        };
    }
}
