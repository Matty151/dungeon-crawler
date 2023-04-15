using Godot;
using RogueLike.Scripts.MapGenerator.Rooms;

namespace RogueLike.Scripts.MapGenerator;

public partial class MapGenerator : Node2D
{
    [Export]
    private int maxRooms = 10;

    public Room GenerateMap()
    {
        Room startRoom = new SquareRoom();

        return startRoom;
    }
}
