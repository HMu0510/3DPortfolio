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
        //subState check...plz;;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LJap") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("RJap") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("LHook") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("RHook") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("LStraight") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("RStraight") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("LUpper") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("RUpper"))
        {
            anim.SetBool("ATTACK", true);
        }
        else
        {
            anim.SetBool("ATTACK", false);
        }
    }
    public void LPunch()
    {
        anim.SetBool("ATTACK", true);
        anim.SetTrigger("LPUNCH");

    }
    public void RPunch()
    {
        anim.SetBool("ATTACK", true);
        anim.SetTrigger("RPUNCH");

    }
    public void LKICK()
    {
        anim.SetBool("ATTACK", true);
        anim.SetTrigger("LKICK");

    }
    public void RKICK()
    {
        anim.SetBool("ATTACK", true);
        anim.SetTrigger("RKICK");

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

}
