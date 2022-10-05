using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject PlayerModel;
    [SerializeField] GameObject ListBrick;
    // [SerializeField] UnBrickController UnBrick;
    [SerializeField] Material UnBrickmaterial;
    Vector3 beginPos;
    Vector3 direction;
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
    RaycastHit unBrickHit;
    RaycastHit wallHit;

    Vector3 prePos;
    [SerializeField] Transform startBrick;
    int brickLayer ;
    int unBrickLayer;
    int wallLayer;
    int numberOfBrick;
    float Thickness;

    List<GameObject> listOfBricks;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        brickLayer = LayerMask.GetMask("BrickLayer");
        unBrickLayer = LayerMask.GetMask("UnBrickLayer");
        wallLayer = LayerMask.GetMask("WallLayer");
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

        Vector3 pos = isWall();
        // pos.z = transform.position.y -0.5f;
        // pos.x = transform.position.x -0.5f;
        pos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
        
        
        //Remove Brick in wall
        if(isBrick())
        {
            AddBrick();
        }

        //Add Brick in wall
        if(isUnBrick() )
        {
            RemoveBrick();
            unBrickHit.collider.enabled= false;
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
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Number brick: "+ listOfBricks.Count);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            rb.velocity = new Vector3( 0, 0, speed);
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
            direction = Vector3.forward;
            // rb.velocity = new Vector3(0, 0,speed );
            break;
        case EDirection.Backward:
            direction = Vector3.back;
            // rb.velocity = new Vector3(0, 0,-speed );
            break;
        case EDirection.Right:
            direction = Vector3.right;
            // rb.velocity = new Vector3(speed , 0,0);
            break;
        case EDirection.Left:
            direction = Vector3.left;
            break;
        default :
            direction = startBrick.position;
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
            PlayerPos.y = PlayerModel.transform.position.y;
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
        RaycastHit hitBrick;
        if(Physics.Raycast(transform.position, Vector3.down, out hitBrick, 25f,brickLayer))
        {
            hitBrick.collider.gameObject.SetActive(false);
            return true;
        }   
        return false;
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag =="end")
        {
            Debug.Log("Collider end");
            rb.velocity = new Vector3(0, 0 ,speed);
        }
    }
    bool isUnBrick()
    {
    
        
        if(Physics.Raycast(transform.position, Vector3.down, out unBrickHit, 50f,unBrickLayer))
        {
            Renderer brickRender = unBrickHit.collider.gameObject.GetComponent<Renderer>();
            Vector3 pos = unBrickHit.collider.gameObject.transform.position;
            pos.y = unBrickHit.collider.gameObject.transform.position.y + 0.8f;
            unBrickHit.collider.gameObject.transform.position = pos;
            
            if(listOfBricks.Count>1)
            {
                brickRender.material= UnBrickmaterial;
            }
                
            return true;
        }   
        
        return false; 
    }

    Vector3 isWall()
    {   
        
        
        if(Physics.Raycast(transform.position, direction, out wallHit, 10f, wallLayer))
        {
            
            Vector3 pos = wallHit.transform.position;
            pos.z = wallHit.transform.position.z -0.5f;
            pos.x = wallHit.transform.position.x -0.5f;
            pos.y = transform.position.y;
            Debug.DrawLine(transform.position, pos, Color.red, 5f);
            return pos;
        }   
        return transform.position;
    }

   

    void SetDeActivate(GameObject go)
    {
        go.SetActive(false);
    }

    
}
