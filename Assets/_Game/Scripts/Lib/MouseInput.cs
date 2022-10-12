using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : Singleton<MouseInput>
{
    private Vector3 direction;
    private Vector2 firstMouse;
    private Vector2 secondMouse;
    public EDirection eDirection;
    public bool isMove = false;

    private void Update() {
        Swipe();
    }
    public void Swipe()
    {   
        
        if(Input.GetMouseButtonDown(0))
        {   
            
            firstMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {   

            secondMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 distance = secondMouse - firstMouse;
            distance.Normalize();
            if (distance.y > 0 && distance.x > -0.5f && distance.x < 0.5f)
            {
                eDirection = EDirection.Forward;
                Debug.Log("up");
            }

            
            if (distance.y < 0 && distance.x > -0.5f && distance.x < 0.5f)
            {
                
                    eDirection = EDirection.Backward;
                
            }
            //swipe left
            if (distance.x < 0 && distance.y > -0.5f && distance.y < 0.5f)
            {
                eDirection = EDirection.Left;
            }
           
            if (distance.x > 0 && distance.y > -0.5f && distance.y < 0.5f)
            {
                
               eDirection = EDirection.Right;
            }
        }
    }

    public EDirection GetEDirection()
    {
      
        return eDirection;
       
    }

    
}
