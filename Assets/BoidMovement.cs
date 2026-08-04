using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// TODO: Implement this movement in 3D
public class BoidMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(Random.Range(0, speed), Random.Range(0, speed), 0);
        rb.linearVelocity = velocity;
        gameObject.transform.rotation = Quaternion.LookRotation(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindClosestBoid()
    {
        GameObject closestBoid = GameObject.FindWithTag("Boid");
        return closestBoid;
    }

    public float DistanceToClosestBoid(GameObject closestBoid)
    {
        return Vector3.Distance(gameObject.transform.position, closestBoid.transform.position);
    }

    public void SteerAwayFromClosestBoid()
    {
        GameObject closestBoid = FindClosestBoid();
        if (closestBoid)
        {
            Vector3 position = closestBoid.transform.position;
            if (DistanceToClosestBoid(closestBoid) <= 20)
            {
                //rb.linearVelocity.
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
            rb.linearVelocity = velocity;
            gameObject.transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}
