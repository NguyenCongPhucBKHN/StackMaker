using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{   
    [SerializeField] Transform BrickTransform;
    [SerializeField] Transform PlayerTransform;
    
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        Vector3 pos = BrickTransform.position;
        pos.x = PlayerTransform.position.x;
        pos.z = PlayerTransform.position.z;
        BrickTransform.position = pos;
    }


}
