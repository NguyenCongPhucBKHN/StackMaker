using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
   
    public List<Level> levels = new List<Level>();
    public Player player;
    Level currentLevel;
    int level;
    private void Start() 
    {   
        level =1;
        GameManager.Instance.ChangeState(EGameState.GamePlay);
        LoadLevel(level);
        OnInit();
        UIManager.Instance.OpenMainMenuUI();
    }
    
   public void LoadLevel(int level)
   {
    if(currentLevel!= null)
    {
        Destroy(currentLevel.gameObject);
    }
    currentLevel = Instantiate(levels[level-1]);
    OnInit();
   }
   
   public void OnInit()
   {
        player.OnInit();
        player.transform.position = currentLevel.startPoint.position + Vector3.up*3f;
   }
   public void OnStart()
   {
        player.isPlay = true;
   }
   public void OnFinsih()
   {
        UIManager.Instance.OpenFinishUI();
        GameManager.Instance.ChangeState(EGameState.Finish);
   }

   public void LoadRePlayLevel() //Choi lai tu man 1
   {    
        player.score =0;
        level = 1;
        LoadLevel(level);
        OnInit();
   }

   public void LoadNextLevel()
   {
    level = Common.MathMod(level, levels.Count);
    level ++;
    LoadLevel(level);
    OnInit();
   }

   public float GetScore()
   {
     return player.score;
   }
   public float GetLevel()
   {
    return level;
   }
}
