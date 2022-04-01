using System;
using UnityEngine;

public class LoseOnCollision : MonoBehaviour
{
    private GameOver gameOver;

    private void Awake()
    {
        gameOver = FindObjectOfType<GameOver>();
    }

    private void OnCollisionEnter2D(Collision2D collidingObj)
    {
        if (collidingObj.gameObject.GetComponent<Asteroid>() == null)
            return;
        gameOver.ShowGameOverUI();
    }
}