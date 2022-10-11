using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] Player player;
    public GameObject win;
    public ParticleSystem[] particleSystems;

    void Update()
    {
        
        if(player.isWin)
        {
            EndAnimation();
            ChangeLevel();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            player.isWin= true;
            Debug.Log("isWin: "+ player.isWin);
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
        // LevelManager.Instance.OnFinsih();
    }


}
