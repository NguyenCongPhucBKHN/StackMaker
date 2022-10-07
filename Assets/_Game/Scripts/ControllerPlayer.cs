using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed=5;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject PlayerModel;
    [SerializeField] GameObject ListBrick;
    // [SerializeField] UnBrickController UnBrick;
    [SerializeField] Material UnBrickmaterial;
    [SerializeField] Transform beginPos;
    [SerializeField] Transform endPos;
    [SerializeField] GameObject winPos;
    [SerializeField]  ParticleSystem[] particleSystems;

    Vector3 firstMousePos;
    Vector3 direction;
    Vector3 secondMousePos;
    Vector3 fisrtBrick;
    Vector3 PlayerPos;
    GameObject topBrick;
    GameObject buttomBrick;
    Rigidbody rb;
    RaycastHit unBrickHit;
    RaycastHit wallHit;
    public Vector3 target;
    Vector3 prePos;
    float angle;

    [SerializeField] Transform startBrick;
    MouseInput mouseInput;
    PlayerMove playerMove;
    bool isMove;
    int brickLayer ;
    int unBrickLayer;
    int wallLayer;
    int numberOfBrick;
    bool isStart;
    public bool isWin;

    bool isMouse => Input.GetMouseButtonUp(0);

    List<GameObject> listOfBricks;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        brickLayer = LayerMask.GetMask("BrickLayer");
        unBrickLayer = LayerMask.GetMask("UnBrickLayer");
        wallLayer = LayerMask.GetMask(Const.LAYER_WALL);
        mouseInput = GetComponent<MouseInput>();
        playerMove = GetComponent<PlayerMove>();

    }
   
    void Start()
    {
      prePos = transform.position;
      listOfBricks= null;
      listOfBricks = new List<GameObject>();
      fisrtBrick = transform.position;
      PlayerPos = PlayerModel.transform.position;
      isMove =false;
      isStart= false;
      target = transform.position;
      
    }

    void Update()
    {
        MoveBrick();
        checkMove();
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("isEnd: "+ isEnd());
        }
        Debug.Log("IsWin in player"+ isWin);
        Debug.Log("dk: "+ (GameManager.Instance.IsState(EGameState.GamePlay)&&isMouse && !isWin ));
        if(GameManager.Instance.IsState(EGameState.GamePlay)&&isMouse && !isWin)
        {
            target = GetPostion();
            
        }
        
        if(!isWin)
        {
            MoveToPoint(target);
            // playerMove.MoveToPoint(target);
           
        }
        // if(isWin)
        // {
        //      transform.position = new Vector3 (-0.5f, 0, 0.5f);
        // }           
       
        if(isBrick())
        {
            AddBrick();
        }
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

        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            rb.velocity = new Vector3( 0, 0, speed);
        }
    }

    public void OnInit()
    {
     transform.position = new Vector3(-0.5f, 0, 0.5f);
     target = new Vector3(-0.5f, 0, 0.5f);
     isWin = false;
     GameManager.Instance.ChangeState(EGameState.GamePlay);
        
    }
    Vector3 Control()
    { 
        EDirection eDirection = mouseInput.GetEDirection();
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

    void Control1()
    { 
        EDirection eDirection = GetDirection();
       switch (eDirection) {
        case EDirection.Forward:
             rb.velocity = Vector3.forward*speed;
             break;
        case EDirection.Backward:
             rb.velocity = Vector3.back*speed;
             break;
            
           
        case EDirection.Right:
            rb.velocity = Vector3.right*speed;
             break;
           
        case EDirection.Left:
            rb.velocity = Vector3.left*speed;
            break;
        case EDirection.None:
        default:
           rb.velocity = Vector3.zero;
           break;
        
       }
    }


    void AddBrick()
    {   
        PlayerPos.x = PlayerModel.transform.position.x;
        PlayerPos.z = PlayerModel.transform.position.z;
        topBrick = Instantiate(BrickPrefab, PlayerPos, Quaternion.Euler(90, 0, -180), ListBrick.transform );
        listOfBricks.Add(topBrick);
        PlayerPos.y = topBrick.transform.position.y + 0.3f;
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

    void checkMove()
    {
        if(GetDirection()!= EDirection.None)
        {
            isMove = true;
        }
    }

    EDirection GetDirection(){
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


    
    bool isBrick()
    {
        RaycastHit hitBrick;
        if(Physics.Raycast(transform.position, Vector3.down, out hitBrick, 25f,brickLayer))
        {
            hitBrick.collider.gameObject.SetActive(false);
            Debug.DrawLine(transform.position, hitBrick.collider.transform.position, Color.red, 5f);
            return true;
        }   
        return false;
        
    }

    
    bool isUnBrick()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out unBrickHit, 50f,unBrickLayer))
        {
            Renderer brickRender = unBrickHit.collider.gameObject.GetComponent<Renderer>();
            Vector3 pos = unBrickHit.collider.gameObject.transform.position;
            pos.y = unBrickHit.collider.gameObject.transform.position.y + 0.8f;
            unBrickHit.collider.gameObject.transform.position = pos;
            Debug.DrawLine(transform.position, pos, Color.black, 5f);
            if(listOfBricks.Count>1)
            {
                brickRender.material= UnBrickmaterial;
            }
                
            return true;
        }   
        
        return false; 
    }

    Vector3 GetPostion()
    {   
       direction = mouseInput.GetDirection();
       Debug.Log("direction: " + direction);
        
        if(Physics.Raycast(transform.position, direction, out wallHit, 1000f, wallLayer))
        {
            Vector3 pos = wallHit.transform.position;
            pos.y = transform.position.y;
            Debug.DrawLine(transform.position, pos - direction*1f, Color.green, 5f);
            return pos - direction*1f;
        }   
        return transform.position;
    }

    void MoveToPoint(Vector3 target)
    {    
        transform.position = Vector3.MoveTowards(transform.position, target, 1f);
    }

    bool isEnd()
    {   
       
        Vector3 comparePos = endPos.position;
        return (Mathf.Abs(comparePos.x - transform.position.x)<0.5 && Mathf.Abs(comparePos.z - transform.position.z)<0.5);
    }
    void EndAnimation()
    {
        winPos.SetActive(true);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Play();
            Invoke(nameof(StopEndAnimation), 3f);
        }
    }
    void StopEndAnimation()
    {
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Pause();
        
        }
    }
 
}
