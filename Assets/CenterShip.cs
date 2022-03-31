using UnityEngine;

public class CenterShip : MonoBehaviour
{
    private AsteroidGenerator asteroidGenerator;

    void Start()
    {
        Vector2 position = new Vector2();
        asteroidGenerator = FindObjectOfType<AsteroidGenerator>();
        position.x = asteroidGenerator.rowLenght * asteroidGenerator.x_Space / 2 + asteroidGenerator.x_Space / 2;
        position.y = asteroidGenerator.columnLenght * asteroidGenerator.y_Space / 2 + asteroidGenerator.y_Space / 2;
        gameObject.transform.position = position;
    }
}