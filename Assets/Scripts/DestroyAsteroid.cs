using System;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    private GameOver gameOver;

    private void Awake()
    {
        gameOver = FindObjectOfType<GameOver>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOver.isGameOver)
            return;

        GameObject collisionGameObj = collision.gameObject;
        if (collisionGameObj.GetComponent<Asteroid>() != null)
        {
            Destroy(collisionGameObj);
            GlobalSettings.SumAsteroid();
            EventManager.InvokeOnAsteroidShot();
            Destroy(gameObject);
        }
    }
}