using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakManager : MonoBehaviour
{
   #region Singleton

  private static BreakManager _instance;
  public static BreakManager Instance => _instance;
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
  
  public Sprite[] Sprites;
  // private int maxRows = 17;
  // private int maxCols = 12;
  // public List<int[,]> LevelsData {get;set;}
  // private void Start()
  // {
  //   this.LevelsData = this.LoadLevelsData();
  // }
  // private List<int[,]> LoadLevelsData()
  // {
  //   TextAsset text = Resources.Load("Levels") as TextAsset;

  //   string [] rows = text.text.Split(new string[] {Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);
  //   List<int[,]> levelsData = new List<int[,]>();
  //   int[,] currentLevel = new int[maxRows, maxCols];
  //   int currentRow = 0;

  //   for (int row=0; row < rows.Length;row++)
  //   {
  //     string line = rows[row];

  //     if (line.IndexOf("--")==-1)
  //     {
  //       string[] bricks = line.Split(new char []{','}, StringSplitOptions.RemoveEmptyEntries);
  //       for(int col = 0; col < bricks.Length; col++)
  //       {
  //         currentLevel[currentRow , col] = int.Parse(bricks[col]);
  //       }
  //       currentRow++; //

  //     }
  //     else
  //     {

  //     }
  //   }
  // }


}
