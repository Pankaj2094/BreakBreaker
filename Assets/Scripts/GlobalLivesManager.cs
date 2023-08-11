using System;
using UnityEngine;

public class GlobalLivesManager : MonoBehaviour
{
    #region Singleton

    private static GlobalLivesManager _instance;
    public static GlobalLivesManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public int MaxLives = 5; // Maximum lives allowed
    public int Lives { get; private set; }
    public float TimeToIncreaseLives = 900f; // 15 minutes in seconds
    private float lastLifeIncreaseTime;

    public event Action<int> OnLivesChanged;

    private void Start()
    {
        Lives = MaxLives; // Initialize lives to maximum
        lastLifeIncreaseTime = Time.time;
    }

    private void Update()
    {
        if (Lives < MaxLives)
        {
            float elapsedTime = Time.time - lastLifeIncreaseTime;
            if (elapsedTime >= TimeToIncreaseLives)
            {
                IncreaseLives();
                lastLifeIncreaseTime = Time.time;
            }
        }
    }

    public void DecreaseLives()
    {
        if (Lives > 0)
        {
            Lives--;
            OnLivesChanged?.Invoke(Lives);
        }
        else
        {
            // Handle game over or prevent further gameplay
            Debug.Log("Game Over - No Lives Remaining");
        }
    }

    private void IncreaseLives()
    {
        if (Lives < MaxLives)
        {
            Lives++;
            OnLivesChanged?.Invoke(Lives);
        }
    }
}
