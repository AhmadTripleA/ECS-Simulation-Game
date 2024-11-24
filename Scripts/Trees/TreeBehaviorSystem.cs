using Godot;
using System.Collections.Generic;

public class TreeBehaviorSystem : SystemECS
{
    public override void Update(List<EntityECS> entities, float deltaTime)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<TreeComponent>()) continue;

            var treeComponent = entity.GetComponent<TreeComponent>();

            if (treeComponent.IsChopped)
            {
                // Countdown the respawn timer
                treeComponent.CurrentTimer -= deltaTime;

                if (treeComponent.CurrentTimer <= 0)
                {
                    // Respawn the tree
                    Respawn(treeComponent);
                }
            }
        }
    }

    private void Respawn(TreeComponent treeComponent)
    {
        treeComponent.IsChopped = false;
        treeComponent.CurrentTimer = treeComponent.MaxRespawnTimer;
        treeComponent.CurrentAmount = treeComponent.MaxAmount;
    }
}
