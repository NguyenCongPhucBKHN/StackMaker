using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    bool started;
    Rigidbody rb;
    bool gameOver;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0,0 );
                started = true;
            }
        }
        Debug.DrawLine(transform.position, Vector3.down, Color.red);
        if(Physics.Raycast(transform.position,  Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, 25f, 0);
        }
        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwithDirection();
        }

    }

    void SwithDirection()
    {
        if(rb.velocity.z>0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x>0)
        {
            rb.velocity = new Vector3( 0, 0, speed);
        }
    }
}
