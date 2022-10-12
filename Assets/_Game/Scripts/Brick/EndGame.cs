using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private bool isPlay;
    public GameObject win;
    public ParticleSystem[] particleSystems;
    private Player player;

    private void Awake() 
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(isPlay)  //Co play PX
        {
            EndAnimation(); //Play PX
        }
        else
        {
            StopEndAnimation(); //Stop PX
        }
        //  Invoke(nameof(ResetDisplay), 15f);
    }
    void ResetDisplay()   //Reset co PX
    {
        isPlay = false;
    }
    void OnTriggerEnter(Collider other)  //Phat hien va cham Player va diem dich
    {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            isPlay= true;                       //Set co play PX
            player.isWin = true;                //Set co win cua Players
        }
    }

    //Ham play PX;
    void EndAnimation()
    {
        win.SetActive(true);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
           
        }
    }
    //Ham end PX
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
