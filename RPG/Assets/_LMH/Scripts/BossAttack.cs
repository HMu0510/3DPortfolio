//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject groundSpikeEft;
    [SerializeField] private GameObject darkSliceEft;
    [SerializeField] private GameObject explosionEft;
    [SerializeField] private GameObject deathRayEft;
    private GameObject groundSpike;
    private GameObject darkSlice;
    private GameObject explosion;
    private GameObject deathRay;

    public Transform[] telPoint;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        groundSpike = Instantiate(groundSpikeEft);
        darkSlice = Instantiate(darkSliceEft);
        explosion = Instantiate(explosionEft);
        deathRay = Instantiate(deathRayEft);
        groundSpike.SetActive(false);
        darkSlice.SetActive(false);
        explosion.SetActive(false);
        deathRay.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        if(Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("TELEPORT");
        }
    }

    private void LateUpdate()
    {
        anim.ResetTrigger("SPELL1");
        anim.ResetTrigger("SPELL2");
        anim.ResetTrigger("SPELL3");
    }

    private void DistanceCheck()
    {

        float dis = Vector3.Distance(playerPos.position, transform.position);
        if (dis <= 1.0f && anim.GetCurrentAnimatorStateInfo(0).IsName("Grogy"))
        {
            anim.ResetTrigger("SPELL1");
            anim.ResetTrigger("SPELL2");
            anim.ResetTrigger("SPELL3");
            anim.SetTrigger("TELEPORT");
        }
        else if(dis <= 4.0f)
        {
            int setNum = Random.Range(1, 3);
            if(setNum == 1)
            {
                anim.SetTrigger("SPELL1");

            }
            else if(setNum == 2)
            {
                anim.SetTrigger("SPELL2");
                
            }
            else if(setNum == 3)
            {
               anim.SetTrigger("SPELL3");
            }
        }
        else
        {
            anim.SetTrigger("SPELL1");
        }
            //anim.SetTrigger("SPELL4");
    }
    private void GroundSpike()
    {
        groundSpike.SetActive(true);
        groundSpike.transform.position = transform.position;
        //groundSpike.transform.rotation = transform.rotation;
    }
    private void DarkSlice()
    {
        darkSlice.SetActive(true);
        darkSlice.transform.position = transform.position;
        //darkSlice.transform.rotation = transform.rotation;
    }
    private void Explosion()
    {
        explosion.SetActive(true);
        explosion.transform.position = transform.position;
        //explosion.transform.rotation = transform.rotation;
    }
    private void DeathRay()
    {
        deathRay.SetActive(true);
        deathRay.transform.position = transform.position;
        //deathRay.transform.rotation = transform.rotation;
    }
    private void Teleport()
    {
        int num = Random.Range(0, telPoint.Length);
        Debug.Log("Tel" + num);
        transform.position = telPoint[num].position;
    }
}
