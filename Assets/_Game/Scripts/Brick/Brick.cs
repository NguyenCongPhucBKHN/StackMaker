using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{


   
   [SerializeField] GameObject BrickPrefab;
   Transform PlayerPos;
   GameObject ListBrick;
   Player player;
   bool isCollect;
   Vector3 pos;
   GameObject topBrick;
//    public List<GameObject> listOfBricks;

    private void Awake() 
    {
        // listOfBricks = new List<GameObject>();
        PlayerPos = GameObject.FindGameObjectWithTag(CONST.TAG_POSE_PLAYER).transform;
        ListBrick = GameObject.Find(CONST.GO_LISTBRICK);
        player = GameObject.FindObjectOfType<Player>();
    }
   private void OnTriggerEnter(Collider other) 
   {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {   
            // other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            AddBrick();
        }
   }

   public void AddBrick()
    {   
        pos = PlayerPos.position;
        
        topBrick = Instantiate(BrickPrefab, pos, Quaternion.Euler(90, 0, -180), ListBrick.transform );
        pos.y = topBrick.transform.position.y + 0.3f;
        PlayerPos.position = pos;
        player.score++;
        player.ani.Play(CONST.ANI_ADDBIRCK, 0, 0.5f);
    }
}
