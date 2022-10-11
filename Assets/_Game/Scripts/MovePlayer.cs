using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    EDirection eDirection;
    RaycastHit wallHit;
    int wallLayer;
    void Awake()
    {
        wallLayer = LayerMask.GetMask(CONST.LAYER_WALL);
    }
public Vector3 GetTargetPosition(EDirection direction)
    {
       Vector3 dir= Vector3.zero;
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
        default :
            break;
       }
       if(Physics.Raycast(Player.position, dir, out wallHit, Mathf.Infinity, wallLayer))
       {
            Vector3 pos = wallHit.transform.position;
            Debug.DrawLine(transform.position, pos - dir*1f, Color.green, 5f);
            pos.y = Player.position.y;
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
    {
        Vector3 pose = GetTargetPosition(eDirection);
        Debug.Log("pose: "+ pose);
        MoveToTargetPosition(pose);

    }

}
