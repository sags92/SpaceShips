using System;

public static class EventManager
{
    public static event Action OnAsteroidCollision;
    public static event Action OnAsteroidShot;

    public static void InvokeOnAsteroidCollision() => OnAsteroidCollision?.Invoke();
    public static void InvokeOnAsteroidShot() => OnAsteroidShot?.Invoke();
}