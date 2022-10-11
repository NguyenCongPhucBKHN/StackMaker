using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    EDirection eDirection;
    RaycastHit wallHit;
    int wallLayer;
    Vector3 dir;
    void Awake()
    {
        wallLayer = LayerMask.GetMask(CONST.LAYER_WALL);
    }
    
public Vector3 GetTargetPosition(EDirection direction)
    {
       switch (direction) 
       {
        case EDirection.Backward:
            dir = Vector3.back;
            break;
        case EDirection.Forward:
            dir = Vector3.forward;
            break;
        case EDirection.Left:
            dir = Vector3.left;
            break;
        case EDirection.Right:
            dir = Vector3.right;
            break;
        case EDirection.None:
            break;
        default :
            break;
       }
       
       if(Physics.Raycast(Player.position, dir, out wallHit, Mathf.Infinity, wallLayer))
       {
            Debug.Log("dir: "+ dir);
            
            Vector3 pos = wallHit.transform.position;
            pos.y = Player.position.y;
            Debug.Log("pos "+ pos);
            Debug.DrawLine(Player.position, pos - dir*1f, Color.green, 5f);
            return pos - dir*1f;
       }
       return Player.position;
    }
    
    public void MoveToTargetPosition(Vector3 target)
    {
        Debug.Log("target: "+ target);
        Player.position =  Vector3.MoveTowards(Player.position, target, 1f);
    }

    public void Move()
    {   eDirection =MouseInput.Instance.GetEDirection();
        Vector3 pose = Player.position;
        pose = GetTargetPosition(eDirection);
        MoveToTargetPosition(pose);
    }

}
