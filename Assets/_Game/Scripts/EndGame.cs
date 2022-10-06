using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform EndTransform;
    public Transform PlayerTransform;
    public GameObject win;
    public ParticleSystem[] particleSystems;
    
    // Update is called once per frame
    void Update()
    {
        if(isEnd())
        {
            EndAnimation();
        }
    }
    bool isEnd()
    {   
        Vector3 comparePos = EndTransform.position;
        return (Mathf.Abs(comparePos.x - PlayerTransform.position.x)<0.5 && Mathf.Abs(comparePos.z - PlayerTransform.position.z)<0.5);
    }   

    void EndAnimation()
    {
        win.SetActive(true);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Play();
            Invoke(nameof(StopEndAnimation), 3f);
        }
    }
    void StopEndAnimation()
    {
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Pause();
        
        }
    }


}
