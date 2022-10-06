using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
   
    public List<Level> levels = new List<Level>();
    public ControllerPlayer player;
    private void Start() {
        LoadLevel(1);
        OnInit();
    }
    Level currentLevel;
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

   }
}
