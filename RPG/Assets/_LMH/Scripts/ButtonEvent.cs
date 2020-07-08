using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Update()
    {

        if (Input.GetButtonDown("LPunch"))
        {
            LPunch();
        }
        if (Input.GetButtonDown("RPunch"))
        {
            RPunch();
        }
        if(Input.GetButtonDown("Dodge"))
        {
            DODGE();
        }
        if(Input.GetButtonDown("Skill1"))
        {
            KickCombo();
        }
        if(Input.GetButtonDown("Skill2"))
        {
            SpinKick();
        }
        if (Input.GetButtonDown("Skill3"))
        {
            OnePunch();
        }
        if(Input.GetButtonDown("Jump"))
        {
            JUMP();
        }
        //subState check...plz;;


    }
    private void LateUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK"))
        {
            anim.SetBool("ATTACK", true);
        }
        else
        {
            anim.SetBool("ATTACK", false);
            anim.ResetTrigger("LPUNCH");
            anim.ResetTrigger("RPUNCH");
            anim.ResetTrigger("KICK");
            anim.ResetTrigger("HKICK");
            anim.ResetTrigger("ONEPUNCH");
            anim.ResetTrigger("DOWN");
            anim.ResetTrigger("LAND");
            //anim.ResetTrigger("KICK");
        }
    }
    public void LPunch()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("LPUNCH");
        }
    }
    public void RPunch()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("RPUNCH");
        }

    }
    public void KickCombo()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("KICK");
        }
    }
    public void SpinKick()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("HKICK");
        }
    }
    public void OnePunch()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("ONEPUNCH");
        }
    }
    public void MOVE()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetBool("IDLE", false);
            anim.SetBool("RUN", false);
            anim.SetBool("MOVE", true);
        }
    }
    public void RUN()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetBool("IDLE", false);
            anim.SetBool("MOVE", false);
            anim.SetBool("RUN", true);
        }
    }
    public void DODGE()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
        {
            anim.SetTrigger("DODGE");
        }
    }
    public void JUMP()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            anim.SetTrigger("JUMP");
        }
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
