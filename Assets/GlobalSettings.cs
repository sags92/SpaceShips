using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    private static int count;
    public static List<Vector2> GLOBALFORCES = new List<Vector2>();

    public static int AsteroidsDestroyed()
    {
        return count;
    }

    public static void SumCountAsterioids()
    {
        count++;
    }

    public static void Spawn(GameObject prefab, Vector3 spawnPoint)
    {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
}