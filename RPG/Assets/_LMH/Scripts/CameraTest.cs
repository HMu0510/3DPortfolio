using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.ImageEffects;

public class CameraTest : MonoBehaviour
{
    [SerializeField] private GameObject fl;
    SmoothFollow sf;
    VignetteAndChromaticAberration vac;
    public bool start = false;

    private void Start()
    {
        sf = Camera.main.GetComponent<SmoothFollow>();
        vac = Camera.main.GetComponent<VignetteAndChromaticAberration>();
    }
    private void Update()
    {
        if(start)
        {
            Vector3 dir = transform.position - Camera.main.transform.position;
            dir.Normalize();
            Camera.main.transform.forward = dir;
            Camera.main.transform.Translate(Camera.main.transform.forward* 8 * Time.deltaTime);
            //vac.m_Intensity
            if (Vector3.Distance(Camera.main.transform.position,transform.position) < 5)
            {
                sf.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        {

            fl.gameObject.SetActive(true);
            start = true;

        }
    }
}
