using System;
using Godot;

namespace RogueLike.Scripts.MapGenerator;

public partial class MapRenderer : Node2D
{
    [Export]
    private MapGenerator mapGenerator;

    public override void _Ready()
    {
        Room startRoom = this.mapGenerator.GenerateMap();
    }
}
