using Godot;

public class TreeComponent : ComponentECS
{
    public bool IsChopped { get; set; } = false;
    public float MaxRespawnTimer { get; set; } = 5.0f;
    public float CurrentTimer { get; set; } = 0;

    public int MaxAmount { get; set; } = 20;
    public int CurrentAmount { get; set; } = 0;

    public TreeComponent()
    {

    }
}
