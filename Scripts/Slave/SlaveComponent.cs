using Godot;
using Common;

public class SlaveComponent : ComponentECS
{
    public float Health = 100.0f;
    public float Speed = 5.0f;
    public float MiningSpeed = 5.0f;
    public Inventory inventory = new Inventory();
    public int CurrentAmount = 0;

    public SlaveComponent()
    {

    }
}
