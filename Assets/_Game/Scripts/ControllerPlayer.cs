using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    bool started;
    EDirection eDirection;
    Vector3 firstPos;
    Vector3 secondPos;
    Rigidbody rb;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        Debug.Log("Direction: " + GetDirection());   
    }

    void OnInit()
    {
        started = false;
    }
    void Control()
    {
        eDirection = GetDirection();
       switch (eDirection) {
        case EDirection.Forward:
            rb.velocity = new Vector3(0, 0,speed );
            break;
        case EDirection.Backward:
            rb.velocity = new Vector3(0, 0,-speed );
            break;
        case EDirection.Right:
            rb.velocity = new Vector3(speed , 0,0);
            break;
        case EDirection.Left:
            rb.velocity = new Vector3(-speed,0, 0 );
            break;
        default :
            rb.velocity = new Vector3(0, 0,0);
            break;
       }
    }
    void AddBrick()
    {
        
    }
    void RemoveBrick()
    {

    }
    void ClearBrick()
    {

    }

    void ChangAnim()
    {

    }

    EDirection GetDirection(){
        float angle = GetAngle();
        if(-135<=angle && angle<-45)
        {
            return EDirection.Backward;
        }
        else if(-45<=angle && angle<45)
        {
            return EDirection.Right;
        }
        else if(45<=angle && angle<135)
        {
            return EDirection.Forward;
        }
        else
        {
            return EDirection.Left;
        }
    }


    float GetAngle()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
            // Debug.Log("fisrtPos"+ firstPos);
        }
        if(Input.GetMouseButtonUp(0))
        {
            secondPos = Input.mousePosition;
            // Debug.Log("secondPos"+ secondPos);
        }
        Vector3 targetDir = secondPos - firstPos;
        float angle = Vector3.SignedAngle(targetDir, Vector3.right, -Vector3.forward);
        // Debug.Log("angle: "+ angle);
        return angle;
    }


    
}
