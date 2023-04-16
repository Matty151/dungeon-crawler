using System.Collections.Generic;
using System.Linq;
using com.matty.Grid2d;
using Godot;
using RogueLike.Scripts.MapGenerator.Rooms;

namespace RogueLike.Scripts.MapGenerator;

public partial class MapGenerator : Node2D
{
    [Export]
    private int gridWidth = 10;

    [Export]
    private int gridHeight = 10;

    [Export]
    private int amountOfDesiredRooms = 10;

    private int curAmountOfRooms;

    [Export]
    private bool allowLoops;

    [Export]
    private float roomCreationChance = 0.5f;

    [Export]
    private int maxTries = 100;

    private int tries;

    private Grid2d<Room> map;
    private Queue<Room> queue = new();

    public MapGenerator()
    {
        this.map = new(this.gridWidth, this.gridHeight);
    }

    public Grid2d<Room> GenerateMap()
    {
        int centerX = this.gridWidth / 2;
        int centerY = this.gridHeight / 2;

        while (this.curAmountOfRooms != this.amountOfDesiredRooms && ++this.tries < this.maxTries) {
            Room startRoom = new SquareRoom(new(centerX, centerY));

            this.map.Clear();
            this.map.SetCellValue(centerX, centerY, startRoom);

            this.queue.Clear();
            this.queue.Enqueue(startRoom);

            this.curAmountOfRooms = 1;

            this.GenerateFloor();
        }

        GD.Print($"Tries: {this.tries}");

        return this.map;
    }

    private void GenerateFloor()
    {
        while (this.queue.TryDequeue(out Room room)) {
            foreach (Vector2I neighbourCoord in this.map.GetNeighbourCoords(room.GridPosition)) {
                if (!this.ShouldCreateRoom(neighbourCoord)) {
                    continue;
                }

                if (this.curAmountOfRooms == this.amountOfDesiredRooms) {
                    break;
                }

                Room newRoom = new SquareRoom(neighbourCoord);

                this.map.SetCellValue(neighbourCoord, newRoom);
                this.queue.Enqueue(newRoom);
                this.curAmountOfRooms++;
            }
        }
    }

    private bool ShouldCreateRoom(Vector2I coords)
    {
        Room room = this.map.GetCellValue(coords);

        if (room != null) {
            return false;
        }

        if (
            this.map.GetNeighbourCoords(coords)
                .Select(this.map.GetCellValue)
                .Count(neighbour => neighbour != null) > (this.allowLoops ? 2 : 1)
        ) {
            return false;
        }

        return GD.Randf() < this.roomCreationChance;
    }
}
