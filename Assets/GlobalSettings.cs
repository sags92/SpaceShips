using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    private static int count;
    public static bool isFirstGame = true;
    public static List<Vector2> GLOBALFORCES = new List<Vector2>();

    public static int TotalDestroyed()
    {
        return count;
    }

    public static void SumAsteroid()
    {
        count++;
    }

    public static void ResetTotalDestroyed()
    {
        count = 0;
    }

    public static Vector2 GetRandomForce()
    {
        return GLOBALFORCES[Random.Range(0, GLOBALFORCES.Count)];
    }
}