using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private bool isDisplay;
    public GameObject win;
    public ParticleSystem[] particleSystems;

    void Update()
    {
        
        if(isDisplay)
        {
            EndAnimation();
        }
        else
        {
            StopEndAnimation();
        }

         Invoke(nameof(ResetDisplay), 15f);
    }
    void ResetDisplay()
    {
        isDisplay = false;
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            isDisplay= true;

        }
    }

    void EndAnimation()
    {
        win.SetActive(true);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
           
        }
    }
    void StopEndAnimation()
    {
        win.SetActive(false);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Pause();
            particle.gameObject.SetActive(false);
        
        }
    }
}
