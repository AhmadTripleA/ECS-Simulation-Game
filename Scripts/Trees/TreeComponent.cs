using Common;
using Godot;

public class TreeComponent : ComponentECS, IMineable
{
    public bool IsChopped = false;
    public float MaxRespawnTimer = 5.0f;
    public float CurrentTimer = 0;
    public int MaxAmount = 20;
    public int CurrentAmount = 0;

    public float MineableFullAmount { get; set; } = 100;
    public float MineableAmount { get; set; } = 100;

    public TreeComponent()
    {

    }
}
