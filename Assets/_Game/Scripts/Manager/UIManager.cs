using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
    public GameObject mainmenuUI;
    public GameObject finishUI;
    public Text score;
    public Text level;
    
    private void Update() {
        score.text = CONST.TEXT_SCORE + LevelManager.Instance.GetScore().ToString();
        level.text = CONST.TEXT_LEVEL + LevelManager.Instance.GetLevel().ToString();
    }
    public void OpenMainMenuUI()
    {
        mainmenuUI.SetActive(true);
        finishUI.SetActive(false);
    }
    public void OpenFinishUI()
    {
        mainmenuUI.SetActive(false);
        finishUI.SetActive(true);
    }
    public void PlayButton()
    {
        mainmenuUI.SetActive(false);
        LevelManager.Instance.OnStart();
        
    }
    public void RePlayButton()
    {
        LevelManager.Instance.LoadRePlayLevel();
        GameManager.Instance.ChangeState(EGameState.MainMenu);
        OpenMainMenuUI();
    }
    public void NextButton()
    {
        LevelManager.Instance.LoadNextLevel();
        GameManager.Instance.ChangeState(EGameState.MainMenu);
        OpenMainMenuUI();
    }

}
