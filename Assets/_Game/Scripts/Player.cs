using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    MovePlayer movePlayer;
    BrickProcess brickProcess;
    ControllerPlayer controllerPlayer;
    Vector3 dir;
    Vector3 position;
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        brickProcess = GetComponent<BrickProcess>();
        controllerPlayer = GetComponent<ControllerPlayer>();
        dir= Vector3.zero;
        position = transform.position;
    }
    private void Update() 
    {
        // EDirection eDirection = MouseInput.Instance.GetEDirection();
        
        // Vector3 position = movePlayer.GetTargetPosition(eDirection);
        // movePlayer.MoveToTargetPosition(position);
        // EDirection direction = MouseInput.Instance.GetEDirection();
        movePlayer.Move();
         
        
           
        
       
        
        // if(controllerPlayer.isBrick())
        // {
        //     controllerPlayer.AddBrick();
        // }

        // if(controllerPlayer.isUnBrick())
        // {
        //     controllerPlayer.RemoveBrick();
        // }

       

        

        // if(brickProcess.isBrick())
        // {
        //     brickProcess.AddBrick();
        // }

        // if(brickProcess.isUnBrick())
        // {
        //     brickProcess.RemoveBrick();
        // }
    }

}
