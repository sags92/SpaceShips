using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class RespawnAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    private AsteroidGenerator asteroidGenerator;
    private CameraInfo cameraInfo;
    private Vector3 mainCamera;
    private float numberX;
    private float numberY;

    private void Awake()
    {
        asteroidGenerator = GetComponent<AsteroidGenerator>();
        EventManager.OnAsteroidCollision += OnAsteroidCollisionHandler;
    }

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>().transform.position;
        cameraInfo = GetComponent<CameraInfo>();
    }

    private void OnAsteroidCollisionHandler()
    {
        while (true)
        {
            numberX = Random.Range(0, asteroidGenerator.rowLenght * asteroidGenerator.x_Space);
            numberY = Random.Range(0, asteroidGenerator.columnLenght * asteroidGenerator.y_Space);

            if (numberX < mainCamera.x - cameraInfo.width ||
                numberX > mainCamera.x + cameraInfo.width && numberY < mainCamera.y - cameraInfo.height ||
                numberY > mainCamera.y + cameraInfo.height)
            {
                Instantiate(asteroidPrefab, new Vector3(numberX, numberY), Quaternion.identity);
                Debug.Log("Asteroid Respawned");
                break;
            }
        }
    }
}