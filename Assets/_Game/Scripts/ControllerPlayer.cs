using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject PlayerModel;
    [SerializeField] GameObject ListBrick;
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
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
    //   prePos = PlayerModel.transform.position;
        prePos = transform.position;
      listOfBricks= null;
      listOfBricks = new List<GameObject>();
      fisrtBrick = transform.position;
      Debug.Log("fisrtBrick: "+ fisrtBrick);
      
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        MoveBrick();
        
        // AddBrick();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // AddBrick();
            Addb();
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

    void Add()
    {
       
        GameObject newBrick = Instantiate(BrickPrefab, PlayerModel.transform.position + Vector3.up*listOfBricks.Count*0.3f,Quaternion.Euler(90, 0, -180), ListBrick.transform );
        listOfBricks.Add(newBrick);
         if(listOfBricks.Count>0)
        {
            PlayerModel.transform.position +=Vector3.up * 0.4f;
            ListBrick.transform.position +=Vector3.up * 0.4f;
        } 
        
    }

    void Add1() //Done
    {   
        
        fisrtBrick.x = transform.position.x;
        fisrtBrick.z = transform.position.z;
        //firstBrick.y luon giu nguyen o z ban dau
        
        lastBrick.y = fisrtBrick.y+ numberOfBrick *0.3f; // toa do y cua brick tren cung gan vao player
        lastBrick.x= fisrtBrick.x;
        lastBrick.z= fisrtBrick.z;
        transform.position = lastBrick;
        GameObject newBrick= Instantiate(BrickPrefab, fisrtBrick, Quaternion.Euler(90, 0, -180), ListBrick.transform);
        listOfBricks.Add(newBrick);
    }

    void RemoveBrick()
    {
        GameObject removeBrick = listOfBricks[0];
        Destroy(removeBrick);
        listOfBricks.RemoveAt(0);
        numberOfBrick = listOfBricks.Count;
        if(numberOfBrick>0)
        {
            GameObject headBrick = listOfBricks[0];
            // PlayerModel.transform.position = headBrick.transform.position;
            PlayerModel.transform.position = headBrick.transform.position;
        }
        else{
            prePos.x = transform.position.x;
            prePos.z = transform.position.z;
            PlayerModel.transform.position = prePos;
        }
        
        Debug.Log("Number Bricks: "+ listOfBricks.Count);
        
    }

     void RemoveBrickb()
    {
        GameObject removeBrick = listOfBricks[0];
        Destroy(removeBrick);
        listOfBricks.RemoveAt(0);
        numberOfBrick = listOfBricks.Count;
        if(numberOfBrick>0)
        {
            GameObject headBrick = listOfBricks[0];
            // PlayerModel.transform.position = headBrick.transform.position;
            PlayerModel.transform.position = headBrick.transform.position;
            ListBrick.transform.position=headBrick.transform.position;
        }
        else{
            prePos.x = transform.position.x;
            prePos.z = transform.position.z;
            PlayerModel.transform.position = prePos;
            ListBrick.transform.position = prePos;

        }
        
        Debug.Log("Number Bricks: "+ listOfBricks.Count);
        
    }

    void RemoveBrick2()
    {
        GameObject removeBrick = listOfBricks[0];
        Destroy(removeBrick);
        listOfBricks.RemoveAt(0);
        numberOfBrick = listOfBricks.Count;
        prePos.x = transform.position.x;
        prePos.z = transform.position.z;
        GameObject headBrick = listOfBricks[0];
        PlayerModel.transform.position = numberOfBrick>0 ? headBrick.transform.position: prePos;
    }



     void Add2() //Tao tren dau: firstBrick
    {   
        
        fisrtBrick.x = transform.position.x;
        fisrtBrick.z = transform.position.z;
        lastBrick.y = fisrtBrick.y + (listOfBricks.Count)*0.3f;
        lastBrick.x= fisrtBrick.x;
        lastBrick.z= fisrtBrick.z;
        transform.position = lastBrick;
        GameObject newBrick= Instantiate(BrickPrefab, fisrtBrick, Quaternion.Euler(90, 0, -180), ListBrick.transform);
        listOfBricks.Add(newBrick);
        PlayerModel.transform.position = lastBrick;
        Debug.Log("Number Bricks: "+ listOfBricks.Count);

    }
    void Addb() //Tao tren dau: firstBrick
    {   
        if(listOfBricks.Count>0){
            fisrtBrick = listOfBricks[listOfBricks.Count-1].transform.position;
        }
        else
        {
            fisrtBrick.x = transform.position.x;
            fisrtBrick.z = transform.position.z;
        }
        
        
        lastBrick.y = fisrtBrick.y + (listOfBricks.Count)*0.3f;
        lastBrick.x= fisrtBrick.x;
        lastBrick.z= fisrtBrick.z;
        ListBrick.transform.position = lastBrick;
        GameObject newBrick= Instantiate(BrickPrefab, fisrtBrick, Quaternion.Euler(90, 0, -180), ListBrick.transform);
        listOfBricks.Add(newBrick);
        PlayerModel.transform.position = listOfBricks[0].transform.position;
        Debug.Log("Number Bricks: "+ listOfBricks.Count);

    }

    










      void Add3() //Tao tren dau: firstBrick
    {   
        
        fisrtBrick.x = transform.position.x;
        fisrtBrick.z = transform.position.z;
        
        
        
        GameObject newBrick= Instantiate(BrickPrefab, fisrtBrick, Quaternion.Euler(90, 0, -180), ListBrick.transform);
        numberOfBrick = listOfBricks.Count;
        lastBrick.x= fisrtBrick.x;
        lastBrick.z= fisrtBrick.z;
        lastBrick.y = prePos.y + (listOfBricks.Count)*0.3f;
        listOfBricks.Add(newBrick);
        transform.position = lastBrick;

    }

    void RemoveBrick3()
    {
        GameObject removeBrick = listOfBricks[0];
        listOfBricks.RemoveAt(0);
        Destroy(removeBrick);
        numberOfBrick = listOfBricks.Count;
        if(numberOfBrick>0)
        {
            GameObject headBrick = listOfBricks[0];
            PlayerModel.transform.position = headBrick.transform.position;

        }
        else
        {
            prePos.x = transform.position.x;
            prePos.z = transform.position.z;
            PlayerModel.transform.position =  prePos;
        }
        
    }


    void AddBrick()
    {   GameObject newBrick;
        newBrick = Instantiate(BrickPrefab, PlayerModel.transform.position + Vector3.up*listOfBricks.Count*0.1f, Quaternion.Euler(90, 0, -180), PlayerModel.transform);
        listOfBricks.Add(newBrick);  
        if(listOfBricks.Count>0)
        {
            // PlayerModel.transform.position += Vector3.up*0.1f;
            
            Vector3 pos = transform.position;
            pos.y = newBrick.transform.position.y;
            transform.position= pos;
            // PlayerModel.transform.localPosition = transform.localPosition+ new Vector3(0,3,0);
            
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
        // Debug.Log("Number Bricks: "+ listOfBricks.Count);
        foreach( GameObject brick in listOfBricks){
            Vector3 pos = brick.transform.position;
            pos.x = transform.position.x;
            pos.z = transform.position.z;
            brick.transform.position = pos;
     }
    }

    
    void RemoveBrick1()
    {
        GameObject removeBrick = listOfBricks[0];
        Destroy(removeBrick);
        listOfBricks.RemoveAt(0);
        if(listOfBricks.Count>0)
        {
            GameObject headBrick = listOfBricks[0];
            transform.position = headBrick.transform.position;
        }
        else{
            prePos.x = transform.position.x;
            prePos.z = transform.position.z;
            transform.position = prePos;
            
        }

        
        
    }
    void ClearBrick()
    {
        foreach(GameObject brick in listOfBricks)
        {
            Destroy(brick);
        }
        listOfBricks.Clear();
        prePos.x= transform.position.x;
        prePos.z= transform.position.z;
        transform.position= prePos;

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
