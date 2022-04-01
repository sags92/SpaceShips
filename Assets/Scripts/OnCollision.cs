using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject asteroid = collision.gameObject;
        if (asteroid.GetComponent<Asteroid>() == null)
            return;

        Destroy(asteroid);
        EventManager.InvokeOnAsteroidCollision();
    }
}