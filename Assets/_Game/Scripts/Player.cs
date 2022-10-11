using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject StartPoint;

    [SerializeField] Transform PlayerTransform;
    MovePlayer movePlayer;
    BrickProcess brickProcess;
    ControllerPlayer controllerPlayer;
    Vector3 dir;
    public bool isWin;

    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        controllerPlayer = GetComponent<ControllerPlayer>();
        dir= Vector3.zero;
    }

    private void Start() 
    {
        OnInit();
    }
    private void Update() 
    {

        movePlayer.Move();
        if(brickProcess.isBrick())
        {
            brickProcess.AddBrick();
        }

        if(brickProcess.isUnBrick())
        {
            brickProcess.RemoveBrick();
            
        }
    }

    public void OnInit()
    {
        dir= Vector3.zero;
        PlayerTransform.position = StartPoint.transform.position+ Vector3.up*3;
    }



}
