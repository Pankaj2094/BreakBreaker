using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  #region Singleton

  private static GameManager _instance;
  public static GameManager Instance => _instance;
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
  public bool IsGameStarted {get;set;}
  public string brickTag = "Brick";
  public GameObject levelCompletePanel;
  private int initialBrickCount;
  
  // public int Lives {get;set;}
  // public int AvailibleLives = 3 ;

  private void Start()
  {
    initialBrickCount = GameObject.FindGameObjectsWithTag(brickTag).Length;
    levelCompletePanel.gameObject.SetActive(false);
    // this.Lives = this.AvailibleLives;
    Screen.SetResolution(720,1280,false);

    // Ball.OnBallDeath += OnBallDeath;
  }

  public void BrickDestroyed()
  {
    initialBrickCount--;
    if(initialBrickCount == 0)
    {
      ShowLevelComplete();
    }
  }
  private void ShowLevelComplete()
  {
    Debug.Log("Level Complete");
    levelCompletePanel.gameObject.SetActive(true);
  }
  // private void OnBallDeath(Ball obj)
  // {
  //   if (BallManager.Instance.Balls.Count <= 0)
  //   {
  //     this.Lives--;
  //     if(this.Lives<1)
  //     {

  //     }
  //     else
  //     {
  //       BallManager.Instance.ResetBalls();
  //       IsGameStarted = false ;
  //       BricksManager.Instance.LoadLevel(BreakManager.Instance.CurrentLevel);
  //     }
  //   }
  // }
  // private void OnDisable()
  // {
  //   Ball.OnBallDeath -= OnBallDeath;
  // }
  
}
