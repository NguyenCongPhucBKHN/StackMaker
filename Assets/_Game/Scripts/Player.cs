using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed=5;
    private MouseInput mouseInput;
    private PlayerMove playerMove;
    private bool isMouse => Input.GetMouseButtonUp(0);
    Vector3 target;
    Vector3 direction;
    RaycastHit wallHit;
    int wallLayer;
    


    private void Awake() {
        mouseInput = GetComponent<MouseInput>();
        playerMove = GetComponent<PlayerMove>();
        
        
    }
    void Start()
    {
        transform.position = new Vector3 (-0.5f, 0, 0.5f);
    }

    void Update()
    {
        if(mouseInput.isMouse)
        {
            
            
        }
        if(mouseInput.isNone())
        {
           
        }

        
        
        
    }

}
