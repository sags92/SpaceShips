using System;
using UnityEngine;

public class LoseOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject ingameUI;
    private AsteroidGenerator asteroidGenerator;

    private void Awake()
    {
        asteroidGenerator = FindObjectOfType<AsteroidGenerator>();
    }

    private void OnCollisionEnter2D(Collision2D collidingObj)
    {
        if (collidingObj.gameObject.GetComponent<Asteroid>() == null)
            return;
        GameOver();
    }

    private void GameOver()
    {
        asteroidGenerator.UnsubscribeOnGameOver();
        gameOverScreen.SetActive(true);
        ingameUI.SetActive(false);
    }
}