using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hit: "+checkBrick());
    }

    private bool checkBrick()
    {
        return Physics.Raycast(transform.position, brick.transform.position, 1.1f);
         
    }
}
