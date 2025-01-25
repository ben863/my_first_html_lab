using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Player movement speed

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Move player based on input
        transform.Translate(moveHorizontal, 0, moveVertical);
    }
}
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float kickForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component for physics
    }

    void Update()
    {
        // Kick the ball when pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KickBall();
        }
    }

    void KickBall()
    {
        // Apply force to the ball in the forward direction
        Vector3 kickDirection = transform.forward * kickForce;
        rb.AddForce(kickDirection, ForceMode.Impulse);
    }
}
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public string goalScoredMessage = "Goal Scored!";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Display goal scored message
            Debug.Log(goalScoredMessage);
            // You can reset the ball position here or handle other goal-related events.
        }
    }
}
