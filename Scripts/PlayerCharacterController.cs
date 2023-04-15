using Godot;

namespace RogueLike.Scripts;

public partial class PlayerCharacterController : CharacterBody2D
{
    [Export]
    private float movementSpeed = 400;

    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("player_move_left", "player_move_right", "player_move_up", "player_move_down");

        this.Velocity = inputDirection * this.movementSpeed;
        this.MoveAndSlide();
    }

    private Vector2 DirectionToMouse()
    {
        return (this.GetGlobalMousePosition() - this.Position).Normalized();
    }
}
