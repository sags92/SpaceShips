using System;

public static class EventManager
{
    public static event Action OnAsteroidCollision;
    public static void InvokeOnAsteroidCollision() => OnAsteroidCollision?.Invoke();
}