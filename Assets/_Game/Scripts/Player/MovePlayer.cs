using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    private Player player;

    private EDirection eDirection;
    private RaycastHit wallHit;
    private int wallLayer;
    private Vector3 dir;

    void Awake()
    {
        wallLayer = LayerMask.GetMask(CONST.LAYER_WALL);
        player = GetComponent<Player>();
    }
    
    //Tim diem dich den tu EDirection nhan tu InputMouse
    public Vector3 GetTargetPosition(EDirection edirection)
    {
       switch (edirection)     //Tim direction
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
            dir= Vector3.zero;
            break;
        default :
            break;
       }
       
       if(Physics.Raycast(Player.position, dir, out wallHit, Mathf.Infinity, wallLayer)) //Ban tia raycast
       {
            Vector3 pos = wallHit.transform.position;
            pos.y = Player.position.y;
            Debug.DrawLine(Player.position, pos - dir*1f, Color.green, 5f);
            return pos - dir*1f;
       }
       return Player.position;
    }

    public void MoveToTargetPosition(Vector3 target, float speed) //Di chuyen den diem target
    {
        Player.position =  Vector3.MoveTowards(Player.position, target, speed*Time.deltaTime<1? speed*Time.deltaTime:1);
    }

    public void Move() //Thuc hien hai ham tren: Tim diem dich va di chuyen den diem dich
    {   eDirection =MouseInput.Instance.GetEDirection();
        Vector3 pose = Player.position;
        pose = GetTargetPosition(eDirection);
        MoveToTargetPosition(pose, 50);
    }
}
