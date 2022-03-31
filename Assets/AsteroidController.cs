using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Vector2 forces;
    private void Start()
    {
        Rigidbody2D AsteroidRB = GetComponent<Rigidbody2D>();
        AsteroidRB.AddForce(forces, ForceMode2D.Force);
    }
}
