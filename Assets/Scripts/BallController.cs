using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 20f; // Movement speed of the ball
    private bool canMove = true; // Flag to control movement

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        if (!canMove) return; // Stop processing movement if disabled

        // Get phone tilt input (accelerometer data)
        Vector3 tilt = Input.acceleration;

        // Apply force based on X and Z tilt values
        Vector3 movement = new Vector3(tilt.x, 0, tilt.y);

        // Add force to the Rigidbody for movement
        rb.AddForce(movement * speed);
    }
    
    // Public method to disable movement
    public void DisableMovement()
    {
        canMove = false;

        // Stop the ball completely
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
