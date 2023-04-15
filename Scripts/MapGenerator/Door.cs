namespace RogueLike.Scripts.MapGenerator;

public class Door
{
    private Room room;
    private int position;

    private Room nextRoom;

    public Door(Room room, int position)
    {
        this.room = room;
        this.position = position;
    }

    public void SetNextRoom(Room room)
    {
        this.nextRoom = room;
    }
}
