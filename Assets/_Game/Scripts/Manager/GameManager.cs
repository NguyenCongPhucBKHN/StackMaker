using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private EGameState gameState;
    public void ChangeState(EGameState gameState)
    {
        this.gameState = gameState;
    }
    public bool IsState(EGameState gameState)
    {
        return this.gameState == gameState;
    }
}
