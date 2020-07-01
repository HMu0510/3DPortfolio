using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void Update()
    {
        if (!anim.GetBool("DIE"))
        {
            if (Input.GetButtonDown("LPunch"))
            {
                LPunch();
            }
            if (Input.GetButtonDown("RPunch"))
            {
                RPunch();
            }
            //subState check...plz;;
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK"))
            {
                anim.SetBool("ATTACK", true);
            }
            else
            {
                anim.SetBool("ATTACK", false);
            }
        }
    }
    public void LPunch()
    {
        anim.SetTrigger("LPUNCH");

    }
    public void RPunch()
    {
        anim.SetTrigger("RPUNCH");

    }
    public void LKICK()
    {
        anim.SetTrigger("LKICK");
    }
    public void RKICK()
    {
        anim.SetTrigger("RKICK");
    }
    public void KickSkill()
    {
        anim.SetTrigger("KICK");
    }
    public void LMOVE()
    {
        anim.SetTrigger("LMOVE");
    }
    public void RMOVE()
    {
        anim.SetTrigger("RMOVE");
    }
    public void MOVE()
    {
        anim.SetBool("IDLE", false);
        anim.SetBool("RUN", false);
        anim.SetBool("MOVE", true);
    }
    public void LRUN()
    {
        anim.SetTrigger("LRUN");
    }
    public void RRUN()
    {
        anim.SetTrigger("RUN");
    }
    public void RUN()
    {
        anim.SetBool("IDLE", false);
        anim.SetBool("MOVE", false);
        anim.SetBool("RUN", true);
    }
    public void IDLE()
    {
        anim.SetBool("MOVE", false);
        anim.SetBool("RUN", false);
        anim.SetBool("IDLE",true);

    }
    public void Die()
    {
        anim.SetBool("DIE", true);
    }

}
