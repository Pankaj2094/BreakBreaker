using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;
    public int Hitpoints =1;
    public ParticleSystem DestroyEffect;
    
    

    public static event Action<Brick> OnBrickDestruction;
    private void Start()
{
   
    this.sr = this.GetComponent<SpriteRenderer>();
    this.sr.sprite = BreakManager.Instance.Sprites[this.Hitpoints - 1];
}

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Ball ball = collision.gameObject.GetComponent<Ball>();
    ApplyCollisionLogic(ball);
  }

private void ApplyCollisionLogic(Ball ball)
{
    this.Hitpoints--;
    if (this.Hitpoints <= 0)
    {
        OnBrickDestruction?.Invoke(this);
        SpawnDestroyEffect();
        Destroy(this.gameObject);

        // Inform the GameManager about the brick destruction
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.BrickDestroyed();
        }
    }
    else
    {
        this.sr.sprite = BreakManager.Instance.Sprites[this.Hitpoints - 1];
    }
}

private void SpawnDestroyEffect()
{
    Vector3 brickPos = gameObject.transform.position;
    Vector3 spawnPosition = new Vector3(brickPos.x, brickPos.y,brickPos.z - 0.2f);
    GameObject effect = Instantiate(DestroyEffect.gameObject,spawnPosition,Quaternion.identity);

    MainModule mm = effect.GetComponent<ParticleSystem>().main;
    mm.startColor = this.sr.color;
    Destroy(effect,DestroyEffect.main.startLifetime.constant);
}

  }

