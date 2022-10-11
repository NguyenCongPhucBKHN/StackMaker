using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Player player;
    // public GameObject win;
    public ParticleSystem[] particleSystems;
    
    private void Awake() {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        OnEndParticle();
    }

    void OnEndParticle()
    {
        if(player.isWin)
        {
            // win.SetActive(true);
            foreach( ParticleSystem particle in particleSystems)
            {
                particle.gameObject.SetActive(true);
                particle.Play();
            
            }
        }
    }
}
