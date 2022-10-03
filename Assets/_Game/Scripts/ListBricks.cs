using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBricks : MonoBehaviour
{
    [SerializeField] GameObject BrickPrefab;
    [SerializeField] Transform Player;
    public List<GameObject> listOfBricks = new List<GameObject>();
    Vector3 Listpos;
    
    void Start()
    {
        Listpos = Player.position;
    }

    public void AddBrick()
    {
        GameObject brick = Instantiate(BrickPrefab, Listpos, Quaternion.Euler(-90, 0, -180));
        brick.transform.SetParent(Player, false);
        listOfBricks.Add(brick);
        if(listOfBricks.Count>0)
        {
            int lastIndex =listOfBricks.Count - 1;
            Listpos = listOfBricks[lastIndex].transform.position + new  Vector3(0,1,0);
        }
        // else
        // {
        //     Listpos = Player.position;
        // }
        
        
    }
}
