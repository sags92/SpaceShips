using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObj = collision.gameObject;
        if (collisionGameObj.GetComponent<Asteroid>() != null)
        {
            Destroy(collisionGameObj);
            Destroy(gameObject);
        }
    }
}