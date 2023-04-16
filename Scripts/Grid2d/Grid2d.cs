using System.Collections.Generic;
using System.Linq;
using Godot;

namespace com.matty.Grid2d;

public class Grid2d<T>
{
    public int Width { get; }
    public int Height { get; }

    private T[,] cells;

    public Grid2d(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        this.Clear();
    }

    public T GetCellValue(int x, int y)
    {
        return this.AreCoordinatesInBounds(x, y) ? this.cells[x, y] : default;
    }

    public T GetCellValue(Vector2I coords)
    {
        return this.GetCellValue(coords.X, coords.Y);
    }

    public void SetCellValue(int x, int y, T value)
    {
        this.cells[x, y] = value;
    }

    public void SetCellValue(Vector2I coords, T value)
    {
        this.SetCellValue(coords.X, coords.Y, value);
    }

    public bool AreCoordinatesInBounds(int x, int y)
    {
        return
            x >= 0 && x < this.Width &&
            y >= 0 && y < this.Height;
    }

    public bool AreCoordinatesInBounds(Vector2I coords)
    {
        return this.AreCoordinatesInBounds(coords.X, coords.Y);
    }

    public Vector2I[] GetNeighbourCoords(int x, int y)
    {
        List<Vector2I> neighbours = new()
        {
            new(x, y - 1), // Top
            new(x + 1, y), // Right
            new(x, y + 1), // Bottom
            new(x - 1, y), // Left
        };

        return neighbours.Where(neighbour => this.AreCoordinatesInBounds(neighbour.X, neighbour.Y)).ToArray();
    }

    public Vector2I[] GetNeighbourCoords(Vector2I coords)
    {
        return this.GetNeighbourCoords(coords.X, coords.Y);
    }

    public void Clear()
    {
        this.cells = new T[this.Width, this.Height];
    }
}
