using Godot;

namespace com.matty.Grid2d;

public class Grid2dScannerIterator<T>
{
    private readonly Grid2d<T> grid;
    private int curX;
    private int curY;

    public Grid2dScannerIterator(Grid2d<T> grid)
    {
        this.grid = grid;
    }

    public bool HasNext()
    {
        return this.grid.AreCoordinatesInBounds(this.curX, this.curY);
    }

    public T GetNext()
    {
        T value = this.grid.GetCellValue(this.curX, this.curY);

        this.curX++;

        // If end of columns is reached, go to start of next row
        if (this.curX == this.grid.Width) {
            this.curX = 0;
            this.curY++;
        }

        return value;
    }
}
