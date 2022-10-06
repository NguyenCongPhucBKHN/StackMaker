using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainmenuUI;
    public GameObject finishUI;
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
        LevelManager.Instance.LoadLevel(1);
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
