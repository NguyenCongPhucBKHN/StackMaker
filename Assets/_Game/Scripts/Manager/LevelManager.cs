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
    }
    
   public void LoadLevel(int level)
   {
    if(currentLevel!= null)
    {
        Destroy(currentLevel.gameObject);
    }
    currentLevel = Instantiate(levels[level-1]);
   }
   
   public void OnInit()
   {
        Vector3 startPos = currentLevel.startPoint.position;
        startPos.y+=3;
        player.transform.position = startPos;
        player.OnInit();
   }
   public void OnStart()
   {
   }
   public void OnFinsih()
   {
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
    level ++;
    LoadLevel(level);
   }

   void CheckLevel()
   {
    
   }

}
