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

    private void Awake() 
    {
        PlayerPos = GameObject.FindGameObjectWithTag(CONST.TAG_POSE_PLAYER).transform;
        ListBrick = GameObject.Find(CONST.GO_LISTBRICK);
        player = GameObject.FindObjectOfType<Player>();
    }

   private void OnTriggerEnter(Collider other)  //Phat hien va cham voi player
   {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {   
            gameObject.SetActive(false);  //Deactivate gach duoi nen
            AddBrick();                     //Them gach vao chan Player
        }
   }

   public void AddBrick()
    {   
        pos = PlayerPos.position;       //Diem add gach
        topBrick = Instantiate(BrickPrefab, pos, Quaternion.Euler(90, 0, -180), ListBrick.transform ); //Tao gach

        pos.y = topBrick.transform.position.y + 0.3f; //Position moi cho player
        PlayerPos.position = pos; 

        player.score++;     //Tang score

        player.ani.Play(CONST.ANI_ADDBIRCK, 0, 0.5f);       //Play animation
    }
}
