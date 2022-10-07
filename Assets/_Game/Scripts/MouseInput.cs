using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private Vector3 firstMousePos;
    private Vector3 secondMousePos;
    private float angle;

    public bool isMouse => Input.GetMouseButtonUp(0);
    private void Start()
    {  
        // Direction = new Dictionary<EDirection, Vector3>();
        // Direction.Add(EDirection.Forward, Vector3.forward);
        // Direction.Add(EDirection.Backward, Vector3.back);
        // Direction.Add(EDirection.Left, Vector3.left);
        // Direction.Add(EDirection.Right, Vector3.right);
        // Direction.Add(EDirection.None, Vector3.zero);
        
    }

    void Update()
    {
        // Debug.Log("GetVDirection(): "+ GetDirection());
    }

    public float GetAngle()
    {   
        if(Input.GetMouseButtonDown(0))
        {
            firstMousePos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            secondMousePos = Input.mousePosition;
        }
        Vector3 targetDir = secondMousePos - firstMousePos;
        float angle = Vector3.SignedAngle(targetDir, Vector3.right, -Vector3.forward);
        return angle;
    }

    public EDirection GetEDirection()
    {
        angle = GetAngle();
        Debug.Log("angle: "+ angle);
        if(-135<=angle && angle<-45)
        {
            return EDirection.Backward;
        }
        else if(Mathf.Abs(angle)<45f && Mathf.Abs(angle)>2f)
        {
            return EDirection.Right;
        }
        else if(45<=angle && angle<135)
        {
            return EDirection.Forward;
        }
        else if( angle >= 135 || angle <-135)
        {
            return EDirection.Left;
        }
        else
        {
            return EDirection.None;
        }
    }

    public bool checkMove()
    {
        if(GetEDirection()!= EDirection.None)
        {
            return true;
        }
        return false;
    }

    public Vector3 GetDirection()
    {
         EDirection eDirection = GetEDirection();
        Debug.Log("eDirection: "+ eDirection);
       switch (eDirection) {
        case EDirection.Forward:
             return Vector3.forward;
        case EDirection.Backward:
            return   Vector3.back;
        case EDirection.Right:
            return Vector3.right;

        case EDirection.Left:
            return  Vector3.left;
        case EDirection.None:
        default :
           return Vector3.zero;
        
       }
    }

    public bool isNone()
    {
        return GetEDirection()!= EDirection.None;
    } 
}
