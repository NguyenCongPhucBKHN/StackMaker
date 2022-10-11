using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimProcess : Singleton< AnimProcess>
{
    [SerializeField] private Animator anim;
    public string currentAnimName;
    public void ChangAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
