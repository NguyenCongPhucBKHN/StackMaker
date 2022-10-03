using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject PlayerModel;
    bool started;
    EDirection eDirection;
    Vector3 firstMousePos;
    Vector3 secondMousePos;
    Vector3 fisrtBrick;
    Vector3 lastBrick;
    Rigidbody rb;
    Vector3 prePos;
    int numberOfBrick;
    float Thickness;

    List<GameObject> listOfBricks;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Thickness = BrickPrefab.transform.localScale.y;
        fisrtBrick = transform.position;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
      prePos = transform.position;
      listOfBricks= null;
      listOfBricks = new List<GameObject>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        MoveBrick();
        Debug.Log("Direction: " + GetDirection());
        // AddBrick();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddBrick();
        }
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
    {   GameObject newBrick;
        newBrick = Instantiate(BrickPrefab, transform.position + Vector3.up*listOfBricks.Count*0.3f, Quaternion.Euler(90, 0, -180));
        listOfBricks.Add(newBrick);  
        if(listOfBricks.Count>0)
        {
            // PlayerModel.transform.position += Vector3.up*0.1f;
            transform.position += Vector3.up*0.1f;
            // transform.position = listOfBricks[listOfBricks.Count-1].transform.position;
        }
    //  foreach( GameObject brick in listOfBricks){
    //         Vector3 pos = brick.transform.position;
    //         pos.x = transform.position.x;
    //         pos.z = transform.position.z;
    //         brick.transform.position = pos;
        
    //     }
    }

    void MoveBrick()
    {   
        Debug.Log("Number Bricks: "+ listOfBricks.Count);
        foreach( GameObject brick in listOfBricks){
            Vector3 pos = brick.transform.position;
            pos.x = transform.position.x;
            pos.z = transform.position.z;
            brick.transform.position = pos;
     }
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
            firstMousePos = Input.mousePosition;
            // Debug.Log("fisrtPos"+ firstPos);
        }
        if(Input.GetMouseButtonUp(0))
        {
            secondMousePos = Input.mousePosition;
            // Debug.Log("secondPos"+ secondPos);
        }
        Vector3 targetDir = secondMousePos - firstMousePos;
        float angle = Vector3.SignedAngle(targetDir, Vector3.right, -Vector3.forward);
        // Debug.Log("angle: "+ angle);
        return angle;
    }


    
}
