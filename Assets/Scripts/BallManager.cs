using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region Singleton

  private static BallManager _instance;
  public static BallManager Instance => _instance;
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
  [SerializeField]
  private Ball ballPrefab;
  private Ball initialBall;
  public float initialBallSpeed = 250;
 
  private Rigidbody2D initialBallRb;
    public List<Ball> Balls {get; set; }
    private void Start()
    {
        InitBall();
    }
    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x,paddlePosition.y+0.27f,0);
            initialBall.transform.position = ballPosition;

            if(Input.GetMouseButtonDown(0))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.AddForce(new Vector2(0,initialBallSpeed));
                GameManager.Instance.IsGameStarted = true;
            }
        }
    }
    // public void ResetBalls()
    // {
    //     foreach (var ball in this.Balls.ToList())
    //     {
    //         Destroy(ball.gameObject);
    //     }
    //     InitBall();
    // }
    private void InitBall()
    {
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y+.27f,0);
        initialBall = Instantiate(ballPrefab,startingPosition,Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
            initialBall
        };
    }
   
}
