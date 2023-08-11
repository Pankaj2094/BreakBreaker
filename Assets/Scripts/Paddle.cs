using UnityEngine;
using System;

public class Paddle : MonoBehaviour
{
    #region Singleton

  private static Paddle _instance;
  public static Paddle Instance => _instance;
  private void Awake()
  {
    if(_instance != null)
    {
        Destroy(gameObject);
    }else
    {
        _instance = this;
    }
  }
  #endregion
    public Transform startPoint; // The leftmost point where the paddle can move
    public Transform endPoint;   // The rightmost point where the paddle can move

    [SerializeField] private float paddleLength = 1.0f; // The length of the paddle

    private float halfPaddleLength; // Half of the paddle length

    private void Start()
    {
        halfPaddleLength = paddleLength * 0.5f;
    }

    private void Update()
    {
        // Get the horizontal input (left and right arrow keys or A and D keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate the target position for the paddle based on the input
        Vector3 targetPosition = transform.position + new Vector3(moveInput, 0f, 0f);

        // Update the halfPaddleLength if paddle size changes
        if (paddleLength != transform.localScale.x)
        {
            paddleLength = transform.localScale.x;
            halfPaddleLength = paddleLength * 0.5f;
        }

        // Clamp the target position to ensure the paddle stays between the start and end points
        float clampedX = Mathf.Clamp(targetPosition.x, startPoint.position.x + halfPaddleLength, endPoint.position.x - halfPaddleLength);
        targetPosition.x = clampedX;

        // Move the paddle to the target position
        transform.position = targetPosition;
    }
     private void OnCollisionEnter2D (Collision2D coll)
    {
         if(coll.gameObject.tag == "Ball")
         {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if(hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference*200)), BallManager.Instance.initialBallSpeed));
            } 
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference*200)),BallManager.Instance.initialBallSpeed));
            } 
         }
    } 
}
