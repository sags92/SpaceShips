using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float speedForce = 2500;
    private float maxSpeed = 120;
    private float rotationSpeed = 150;
    private Rigidbody2D shipCharController;
    private Vector3 velocity;

    private void Awake()
    {
        shipCharController = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 move = transform.up * y;

        shipCharController.AddForce(move * (speedForce * Time.deltaTime));
        velocity = shipCharController.velocity;
        if (velocity.magnitude > maxSpeed)
            shipCharController.velocity = velocity.normalized * maxSpeed;
        gameObject.transform.Rotate(-Vector3.forward * x * (rotationSpeed * Time.deltaTime));
    }
}