using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 20f; // Hareket hızı

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Telefon eğimini alıyoruz
        Vector3 tilt = Input.acceleration;

        // X ve Z eksenlerinde kuvvet uygula
        Vector3 movement = new Vector3(tilt.x, 0, tilt.y);

        // Rigidbody'e kuvvet uygula
        rb.AddForce(movement * speed);
    }
}
