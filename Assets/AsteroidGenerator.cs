using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public int columnLenght, rowLenght;
    public float x_Space, y_Space;
    public GameObject asteroidPrefab;
    private GameObject newAsteroid;
    private CameraInfo cameraInfo;
    private Vector2 randomValues;
    private readonly List<Vector2> globalForcesList = GlobalSettings.GLOBALFORCES;

    private void Awake()
    {
        cameraInfo = FindObjectOfType<CameraInfo>();
        EventManager.OnAsteroidCollision += OnAsteroidCollisionHandler;
        int asteroidCount = 0;

        for (int y = 0; y < rowLenght; y++)
        {
            for (int x = 0; x < columnLenght; x++)
            {
                if (GlobalSettings.isFirstGame)
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
                AddForce(newAsteroid, globalForcesList[asteroidCount]);
                asteroidCount++;
            }
        }

        GlobalSettings.isFirstGame = false;
    }

    public void UnsubscribeOnGameOver()
    {
        EventManager.OnAsteroidCollision -= OnAsteroidCollisionHandler;
    }

    private void OnAsteroidCollisionHandler()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(1);

        float numberX;
        float numberY;

        Vector3 cameraPosition = Camera.main.transform.position;
        while (true)
        {
            numberX = Random.Range(0, rowLenght * x_Space);
            numberY = Random.Range(0, columnLenght * y_Space);

            if (numberX < cameraPosition.x - cameraInfo.width ||
                numberX > cameraPosition.x + cameraInfo.width && numberY < cameraPosition.y - cameraInfo.height ||
                numberY > cameraPosition.y + cameraInfo.height)
            {
                newAsteroid = Instantiate(asteroidPrefab, new Vector3(numberX, numberY), Quaternion.identity);
                AddForce(newAsteroid, GlobalSettings.GetRandomForce());
                break;
            }
        }
    }

    public void AddForce(GameObject asteroid, Vector2 force)
    {
        asteroid.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
    }
}