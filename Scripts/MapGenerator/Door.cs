using Godot;

namespace RogueLike.Scripts.MapGenerator;

public class Door
{
    public Room Room { get; }
    public Vector2 Position { get; }

    public Room NextRoom { get; set; }

    public Door(Room room, Vector2 position)
    {
        this.Room = room;
        this.Position = position;
    }
}
