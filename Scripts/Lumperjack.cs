using Godot;
using System;

public partial class Lumperjack : AnimatableBody2D
{
    // States for lumberjack behavior
    private enum State { Resting, MovingToTree, Chopping, ReturningToHouse }
    private State currentState = State.Resting;

    // Positions for the house and tree
    private Vector2 housePosition;
    private Vector2 treePosition;

    // Movement speed
    private const float speed = 100f;

    // Timer for chopping the tree
    private float choppingTime = 2.0f;

    // Tree respawn state
    private bool treeRespawned = true;

    public override void _Ready()
    {
        // Get references to the house and tree positions
        housePosition = GetParent().GetNode<Node2D>("House").Position;
        treePosition = GetParent().GetNode<Node2D>("Tree").Position;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Handle the lumberjack's state
        switch (currentState)
        {
            case State.Resting:
                // Wait for tree to respawn
                if (treeRespawned)
                {
                    currentState = State.MovingToTree;
                }
                break;

            case State.MovingToTree:
                // Move toward the tree
                Position = MoveTowards(Position, treePosition, (float)(speed * delta));

                // If close to the tree, start chopping
                if (Position.DistanceTo(treePosition) < 5.0f)
                {
                    currentState = State.Chopping;
                }
                break;

            case State.Chopping:
                // Chop the tree
                choppingTime -= (float)delta;
                if (choppingTime <= 0)
                {
                    choppingTime = 2.0f; // Reset chopping timer
                    treeRespawned = false; // Mark the tree as chopped
                    GetParent().GetNode<Sprite2D>("Tree").Visible = false; // Hide the tree

                    // Start tree respawn timer
                    Timer treeRespawnTimer = GetParent().GetNode<Timer>("TreeRespawnTimer");
                    treeRespawnTimer.Start();

                    // Return to house
                    currentState = State.ReturningToHouse;
                }
                break;

            case State.ReturningToHouse:
                // Move toward the house
                Position = MoveTowards(Position, housePosition, (float)(speed * delta));

                // If back at the house, rest
                if (Position.DistanceTo(housePosition) < 5.0f)
                {
                    currentState = State.Resting;
                }
                break;
        }
    }

    private Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
    {
        // Calculate the movement direction and return the new position
        Vector2 direction = (target - current).Normalized();
        return current + direction * maxDistanceDelta;
    }

    // Called when the tree respawn timer finishes
    public void OnTreeRespawn()
    {
        treeRespawned = true;
        GetParent().GetNode<Sprite2D>("Tree").Visible = true; // Show the tree again
    }
}
