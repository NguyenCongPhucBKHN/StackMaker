using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] GameObject StartPoint;

    [SerializeField] Transform PlayerTransform;
    MovePlayer movePlayer;
    BrickProcess brickProcess;
    ControllerPlayer controllerPlayer;
    Vector3 dir;
    public float score =0f;
    public bool isWin;
    public EDirection eDirection;
    public bool isPlay= false;
    
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        controllerPlayer = GetComponent<ControllerPlayer>();
        
    }

    private void Start() 
    {
        OnInit();
    }
    private void Update() 
    {
        if(isPlay)
        {
            eDirection = MouseInput.Instance.GetEDirection();
            Vector3 target = movePlayer.GetTargetPosition(eDirection);
            movePlayer.MoveToTargetPosition(target);
        }
        
       
        
        if(brickProcess.isBrick())
        {
            brickProcess.AddBrick();
            score++;
        }

        if(brickProcess.isUnBrick())
        {
            brickProcess.RemoveBrick();
            score++;
        }

        if(isWin)
        {   
            brickProcess.ClearBrick();
            LevelManager.Instance.OnFinsih();
        }
         
        
    }

    public void OnInit()
    {
        isPlay= false;
        eDirection= EDirection.None;
        // PlayerTransform.position = new Vector3( -0.5f,0, 0.5f);
        isWin = false;
    }
}
