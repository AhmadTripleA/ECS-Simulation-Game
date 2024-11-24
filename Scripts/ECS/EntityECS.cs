using System;
using System.Collections.Generic;

public class EntityECS
{
    private readonly Dictionary<Type, object> _components = new();

    public void AddComponent<T>(T component) where T : class
    {
        _components[typeof(T)] = component;
    }
    public T GetComponent<T>() where T : class
    {
        return _components.TryGetValue(typeof(T), out var component) ? component as T : null;
    }

    public bool HasComponent<T>() where T : class
    {
        return _components.ContainsKey(typeof(T));
    }
}
