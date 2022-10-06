using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform EndTransform;
    public Transform PlayerTransform;
    public GameObject win;
    public ParticleSystem[] particleSystems;
    bool isWin = false;

    
    // Update is called once per frame
    void Update()
    {
        
        if(isWin)
        {
            EndAnimation();
            ChangeLevel();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            isWin= true;
            Debug.Log("isWin: "+ isWin);
        }
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

    void ChangeLevel()
    {
        LevelManager.Instance.OnFinsih();
    }


}
