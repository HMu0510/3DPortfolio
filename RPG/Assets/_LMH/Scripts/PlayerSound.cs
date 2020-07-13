using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioC;
    [SerializeField] AudioSource audioS;

    public void PunchSound()
    {
        int num = Random.Range(0, 1);
        audioS.clip = audioC[num];
        audioS.Play();
    }
    public void StraightSound()
    {
        audioS.clip = audioC[2];
        audioS.Play();
    }
    public void UpperSound()
    {
        audioS.clip = audioC[3];
        audioS.Play();
    }
    public void KickSound()
    {
        audioS.clip = audioC[4];
        audioS.Play();
    }
    public void KickSkillSound()
    {
        audioS.clip = audioC[5];
        audioS.Play();
    }
    public void ChargeSound()
    {
        audioS.clip = audioC[6];
        audioS.Play();
    }

}
