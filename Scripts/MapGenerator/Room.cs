using System;
using System.Collections.Generic;
using Godot;

namespace RogueLike.Scripts.MapGenerator;

public abstract class Room
{
    public string Uuid { get; }
    public Vector2I GridPosition { get; }

    public List<Door> Doors { get; protected init; }

    protected Room(Vector2I gridPosition)
    {
        this.Uuid = Guid.NewGuid().ToString();
        this.GridPosition = gridPosition;
    }
}
