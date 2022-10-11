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

}
