using Godot;
using System.Collections.Generic;

public partial class TreeECSManager : Node
{
    private List<EntityECS> _entities = new();
    private TreeBehaviorSystem _treeBehaviorSystem;

    public override void _Ready()
    {
        // Initialize the system
        _treeBehaviorSystem = new TreeBehaviorSystem();

        // Create a tree entity
        var tree = new EntityECS();
        tree.AddComponent(new TreeComponent());
        _entities.Add(tree);

        // Simulate chopping the tree
        //ChopTree(tree);
    }

    public override void _Process(double delta)
    {
        // Update the tree behavior system
        _treeBehaviorSystem.Update(_entities, (float)delta);
    }

    //private void ChopTree(EntityECS tree)
    //{
    //    var treeComponent = tree.GetComponent<TreeComponent>();
    //    if (treeComponent != null)
    //    {
    //        treeComponent.IsChopped = true;
    //        GD.Print("Tree chopped down!");
    //    }
    //}
}
