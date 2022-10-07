using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
   
    public List<Level> levels = new List<Level>();
    
    public ControllerPlayer player;
    Level currentLevel;
    int level =1;
    private void Start() {
        GameManager.Instance.ChangeState(EGameState.GamePlay);
        LoadLevel(1);
        OnInit();
        UIManager.Instance.OpenMainMenuUI();
        OnStart();
    }
    
   public void LoadLevel(int level)
   {
    if(currentLevel!= null)
    {
        Destroy(currentLevel.gameObject);
    }
    currentLevel = Instantiate(levels[level-1]);
    OnStart();
   }
   
   public void OnInit()
   {
        player.OnInit();
        
   }
   public void OnStart()
   {
        player.isWin = false;
   }
   public void OnFinsih()
   {    
        player.isWin = true;
        UIManager.Instance.OpenFinishUI();
        GameManager.Instance.ChangeState(EGameState.Finish);
        
   }

   public void LoadRePlayLevel()
   {
    LoadLevel(level);
    OnInit();
    
   }

   public void LoadNextLevel()
   {
    
    player.isWin = false;
    
    // player.transform.position = new Vector3(-0.5f, 0, 0.5f);
    level ++;
    LoadLevel(2);
    OnInit();
    
   }


   void CheckLevel()
   {
    
   }

}
