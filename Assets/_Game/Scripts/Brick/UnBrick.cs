using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    [SerializeField] Material UnBrickmaterial;
    [SerializeField] GameObject RenBrick;

    Player player;
    GameObject ListBrick;
    Transform PlayerPos;
    GameObject buttomBrick;
    Collider collider;

    private void Awake() 
    {
       PlayerPos = GameObject.FindGameObjectWithTag(CONST.TAG_POSE_PLAYER).transform;
       ListBrick = GameObject.Find(CONST.GO_LISTBRICK);
       collider = GetComponent<Collider>();
       player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        Vector3 pos = PlayerPos.position;
        
        if(other.CompareTag(CONST.TAG_PLAYER) && ListBrick.transform.childCount>1)
        {
            Renderer brickRender = RenBrick.GetComponent<Renderer>();
            int id_buttom = ListBrick.transform.childCount -1;
            buttomBrick = ListBrick.transform.GetChild(id_buttom).gameObject;
            pos.y = buttomBrick.transform.position.y;
            Destroy(buttomBrick);
            brickRender.transform.position += Vector3.up*0.3f;
            brickRender.material = UnBrickmaterial;
            player.score++;
            player.ani.Play(CONST.ANI_UNBRICK, 0, 0.5f);
        }
        PlayerPos.position = pos;

    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            collider.enabled= false;
        }
    }
}
