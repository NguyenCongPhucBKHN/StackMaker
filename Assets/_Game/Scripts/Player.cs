using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] GameObject StartPoint;

    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject playerModel;
    MovePlayer movePlayer;
    BrickProcess brickProcess;
    ControllerPlayer controllerPlayer;
    Vector3 dir;
    public float score =0f;
    public bool isWin;
    public EDirection eDirection;
    public bool isPlay= false;
    Animator ani;
    
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        controllerPlayer = GetComponent<ControllerPlayer>();
        ani = playerModel.GetComponent<Animator>();
        
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
            ani.Play(CONST.ANI_ADDBIRCK, 0, 0.25f);
            brickProcess.AddBrick();
            score++;
        }

        if(brickProcess.isUnBrick())
        {
            ani.Play(CONST.ANI_UNBRICK, 0, 0.25f);
            brickProcess.RemoveBrick();
            score++;
        }

        if(isWin)
        {   
            ani.Play(CONST.ANI_WIN);
            brickProcess.ClearBrick();
            LevelManager.Instance.OnFinsih();
        }
         
        
    }

    public void OnInit()
    {
        isPlay= false;
        eDirection= EDirection.None;
        ani.Play(CONST.ANI_IDLE, 0, 0.25f);

        // PlayerTransform.position = new Vector3( -0.5f,0, 0.5f);
        // AnimProcess.Instance.ChangAnim("idle");
        isWin = false;
    }
}
