using Godot;
using Common;

public class SlaveComponent : ComponentECS
{
    public float Health = 100.0f;
    public float MovementSpeed = 10.0f;
    public float MiningSpeed = 5.0f;
    public float ChoppingSpeed = 12.5f;
    
    public IMineable MineableTarget;
    public Vector2 MovementTarget;
    public Inventory inventory = new();

    public SlaveComponent()
    {

    }
}
