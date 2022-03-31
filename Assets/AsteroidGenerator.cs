using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public int columnLenght, rowLenght;
    public float x_Space, y_Space;
    public GameObject asteroidPrefab;
    private GameObject newAsteroid;
    private Vector2 randomValues;
    private List<Vector2> globalForcesList = GlobalSettings.GLOBALFORCES;
    private bool firstGame = true;
    private int asteroidCount;

    private void Awake()
    {
        float initialTime = Time.realtimeSinceStartup;
        for (int y = 0; y < rowLenght; y++)
        {
            for (int x = 0; x < columnLenght; x++)
            {
                if (firstGame)
                {
                    while (true)
                    {
                        randomValues.x = Random.Range(-1000, 1000);
                        if (randomValues.x != 0)
                            break;
                    }

                    while (true)
                    {
                        randomValues.y = Random.Range(-1000, 1000);
                        if (randomValues.y != 0)
                            break;
                    }

                    globalForcesList.Add(randomValues);
                }

                newAsteroid = Instantiate(asteroidPrefab,
                    new Vector3(x_Space * x, y_Space * y), Quaternion.identity);
                GlobalSettings.GLOBALFORCES = globalForcesList;
                newAsteroid.GetComponent<AsteroidController>().forces = globalForcesList[asteroidCount];
                asteroidCount++;
            }
        }

        firstGame = false;
        float duration = Time.realtimeSinceStartup - initialTime;
        Debug.Log(duration);
    }
}