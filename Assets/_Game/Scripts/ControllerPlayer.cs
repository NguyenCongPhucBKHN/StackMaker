using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject PlayerModel;
    [SerializeField] GameObject ListBrick;
    Vector3 beginPos;
    bool started;
    EDirection eDirection;
    Vector3 firstMousePos;
    Vector3 secondMousePos;
    Vector3 fisrtBrick;
    Vector3 lastBrick;
    Vector3 PlayerPos;

    GameObject topBrick;
    GameObject buttomBrick;
    Rigidbody rb;

    Vector3 prePos;
    int brickLayer ;
    int numberOfBrick;
    float Thickness;

    List<GameObject> listOfBricks;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        brickLayer = LayerMask.GetMask("BrickLayer");
        beginPos = PlayerModel.transform.position;
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
    //   prePos = PlayerModel.transform.position;
        prePos = transform.position;
      listOfBricks= null;
      listOfBricks = new List<GameObject>();
      fisrtBrick = transform.position;
      PlayerPos = PlayerModel.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        MoveBrick();
        

        // if(isBrick())
        // {
        //     AddBrick();
        // }
        
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            AddBrick();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(listOfBricks.Count>0)
            {
                
                RemoveBrick();
            }
            else
            {
                return;
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            ClearBrick();
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
    {   
        PlayerPos.x = PlayerModel.transform.position.x;
        PlayerPos.z = PlayerModel.transform.position.z;
        topBrick = Instantiate(BrickPrefab, PlayerPos, Quaternion.Euler(90, 0, -180), ListBrick.transform );
        listOfBricks.Add(topBrick);
        PlayerPos.y = topBrick.transform.position.y + 0.4f;
        PlayerModel.transform.position = PlayerPos;
    }

    void RemoveBrick()
    {
        if(listOfBricks.Count>0)
        {
            buttomBrick = listOfBricks[listOfBricks.Count-1];
            PlayerPos.y = buttomBrick.transform.position.y;
            Destroy(buttomBrick);
        }
        else
        {
            PlayerPos.y = 0;
        }

        PlayerPos.x = PlayerModel.transform.position.x;
        PlayerPos.z = PlayerModel.transform.position.z;
        PlayerModel.transform.position = PlayerPos;
        listOfBricks.Remove(buttomBrick);
        
    }

    
    void MoveBrick()
    {   
        
        foreach( GameObject brick in listOfBricks){
            Vector3 pos = brick.transform.position;
            pos.x = transform.position.x;
            pos.z = transform.position.z;
            brick.transform.position = pos;
     }
    }
    void ClearBrick()
    {
        foreach(GameObject brick in listOfBricks)
        {
            Destroy(brick);
        }
        listOfBricks.Clear();
        PlayerPos.x= PlayerModel.transform.position.x;
        PlayerPos.z= PlayerModel.transform.position.z;
        PlayerPos.y= 3;
        PlayerModel.transform.position= PlayerPos;

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
        }
        if(Input.GetMouseButtonUp(0))
        {
            secondMousePos = Input.mousePosition;
        }
        Vector3 targetDir = secondMousePos - firstMousePos;
        float angle = Vector3.SignedAngle(targetDir, Vector3.right, -Vector3.forward);
        return angle;
    }


    Vector3 GetPosition()
    {
        Vector3 transforms= new Vector3(0, 0, 0);

        return transforms;
    }

    bool isBrick()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 25f,brickLayer))
        {
            hit.collider.gameObject.SetActive(false);
            return true;
        }   
        return false;
        
    }

    void SetDeActivate(GameObject go)
    {
        go.SetActive(false);
    }

    
}
