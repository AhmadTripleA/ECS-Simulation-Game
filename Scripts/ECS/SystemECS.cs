using Godot;
using System;
using System.Collections.Generic;

public abstract class SystemECS
{
    public abstract void Update(List<EntityECS> entities, float deltaTime);
}
