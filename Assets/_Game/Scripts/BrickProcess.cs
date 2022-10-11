using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickProcess : MonoBehaviour
{
    [SerializeField] Material UnBrickmaterial;
    [SerializeField] Transform PlayerPos;
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject ListBrick;
    int brickLayer;
    int unBrickLayer;
    GameObject topBrick;
    GameObject buttomBrick;

    RaycastHit unBrickHit;
    List<GameObject> listOfBricks;
    Vector3 pos;

    private void Awake() 
    {
        listOfBricks = new List<GameObject>();
        brickLayer = LayerMask.GetMask(CONST.LAYER_BRICK);
        unBrickLayer = LayerMask.GetMask(CONST.LAYER_UNBRICK);
    }

    private void Start() {
        pos = PlayerPos.position;
    }

    public bool isBrick()
    {   
        RaycastHit hitBrick;
        if(Physics.Raycast(transform.position, Vector3.down, out hitBrick, 25f, brickLayer))
        {
            //Destroy(hitBrick.collider.gameObject);
            hitBrick.collider.gameObject.SetActive(false);
            // Debug.DrawLine(PlayerPos.position, hitBrick.collider.transform.position, Color.red, 5f);
            return true;
        }   
        return false; 
    }

    public bool isUnBrick()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out unBrickHit, 200f,unBrickLayer))
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

    public void AddBrick()
    {   pos = PlayerPos.position;
        topBrick = Instantiate(BrickPrefab, pos, Quaternion.Euler(90, 0, -180), ListBrick.transform );
        listOfBricks.Add(topBrick);
        pos.y = topBrick.transform.position.y + 0.3f;
        PlayerPos.position = pos;
    }

    public void RemoveBrick()
    {
        Vector3 pos = PlayerPos.position;
        if(listOfBricks.Count>0)
        {
            buttomBrick = listOfBricks[listOfBricks.Count-1];
            pos.y = buttomBrick.transform.position.y;
            Destroy(buttomBrick);
        }
        PlayerPos.position = pos;
        listOfBricks.Remove(buttomBrick);
    }

    public void ClearBrick()
    {
        foreach(GameObject brick in listOfBricks)
        {
            Destroy(brick);
        }
        listOfBricks.Clear();
        PlayerPos.position = PlayerPos.position - (PlayerPos.position.y) * Vector3.up;
    }

}
