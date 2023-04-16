using System.Linq;
using com.matty.Grid2d;
using Godot;

namespace RogueLike.Scripts.MapGenerator;

public partial class MapRenderer : Node2D
{
    [Export]
    private MapGenerator mapGenerator;

    public override void _Ready()
    {
        base._Ready();

        Grid2d<Room> map = this.mapGenerator.GenerateMap();
        this.RenderMap(map);
    }

    private void RenderMap(Grid2d<Room> map)
    {
        // for (int x = 0; x < map.Width; x++) {
        //     for (int y = 0; y < map.Height; y++) {
        //         Room room = map.GetCellValue(x, y);
        //
        //         if (room != null) {
        //             this.RenderRoom(x, y, room);
        //         }
        //     }
        // }

        Grid2dScannerIterator<Room> mapIterator = new(map);

        while (mapIterator.HasNext()) {
            Room room = mapIterator.GetNext();

            if (room != null) {
                this.RenderRoom(room);
            }
        }
    }

    private void RenderRoom(Room room)
    {
        PackedScene tileAsset = GD.Load<PackedScene>("res://Assets/Ground.tscn");
        Sprite2D tileInstance = (Sprite2D) tileAsset.Instantiate();
        tileInstance.Translate(new Vector2(room.GridPosition.X * tileInstance.Texture.GetWidth(), room.GridPosition.Y * tileInstance.Texture.GetHeight()));
        this.AddChild(tileInstance);
    }
}
