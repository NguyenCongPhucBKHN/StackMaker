using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform Player;
    private MouseInput mouseInput;
    private Vector3 direction;
    RaycastHit wallHit;
    int wallLayer;

    private void Awake() {
        mouseInput = GetComponent<MouseInput>();
        wallLayer = LayerMask.GetMask(Const.LAYER_WALL);
    }
    
    public Vector3 GetTargetPosition()
    {
        direction = mouseInput.GetDirection();

        if(Physics.Raycast(Player.position, direction, out wallHit, 1000f, wallLayer) && direction!= Vector3.zero)
        {
            Vector3 pos = wallHit.transform.position;
            pos.y = Player.position.y;
            Debug.DrawLine(Player.position, pos - direction*1f, Color.green, 5f);
            return pos - direction*1f;
        }   
        return Player.position;
    }

    public void MoveToPoint(Vector3 target)
    {    
        Player.position = Vector3.MoveTowards(Player.position, target, 1f);
    }




}
   

