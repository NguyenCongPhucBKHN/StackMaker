using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform EndTransform;
    public ControllerPlayer player;
    public GameObject win;
    public ParticleSystem[] particleSystems;
    bool isWin = false;

    
    void Update()
    {
        if(isWin)
        {
            EndAnimation();
            ChangeLevel();
            player.isWin = false;
            
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            isWin= true;
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
        player.isWin = false;
    }

}
