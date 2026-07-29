using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] public float velocityChangeTime;
    private float velocityTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(Random.Range(0, speed), Random.Range(0, speed), Random.Range(0, speed));
        velocityTimer = velocityChangeTime;
    }

    // Update is called once per frame
    void Update()
    {
        velocityTimer -= Time.deltaTime;
        if (velocityTimer < 0f) {
            rb.linearVelocity = new Vector3(Random.Range(0, speed), Random.Range(0, speed), Random.Range(0, speed));
            velocityTimer = velocityChangeTime;
        }
    }
}
