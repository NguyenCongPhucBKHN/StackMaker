using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] GameObject StartPoint;

    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject playerModel;
    [SerializeField] float speed;
    private MovePlayer movePlayer;
    private BrickProcess brickProcess;
    private Vector3 dir;
    private Animator ani;
    public float score =0f;
    public bool isWin;
    public EDirection eDirection;
    public bool isPlay= false;
    
    
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        ani = playerModel.GetComponent<Animator>();
        
    }

    private void Start() 
    {
        OnInit();
    }
    private void Update() 
    {
        if(isPlay &&!isWin)
        {
            eDirection = MouseInput.Instance.GetEDirection();
            Vector3 target = movePlayer.GetTargetPosition(eDirection);
            movePlayer.MoveToTargetPosition(target, speed);
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
