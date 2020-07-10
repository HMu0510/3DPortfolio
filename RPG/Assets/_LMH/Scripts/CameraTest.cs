using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.ImageEffects;

public class CameraTest : MonoBehaviour
{
    [SerializeField] private GameObject fl;
    //[SerializeField] private GameObject joy;
    //[SerializeField] private GameObject button;
    [SerializeField] private GameObject[] UI;
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
            MoveCam();
        }
    }
    public void StartGame()
    {
        {

            fl.gameObject.SetActive(true);
            StartCoroutine("CameraLightMove");

        }
    }
    IEnumerator CameraLightMove()
    {
        yield return new WaitForSeconds(0.2f);
        start = true;
    }
    private void MoveCam()
    {
        Vector3 dir = transform.position - Camera.main.transform.position;
        dir.Normalize();
        Camera.main.transform.forward = dir;
        Camera.main.transform.Translate(Camera.main.transform.forward * 8 * Time.deltaTime);
        //vac.m_Intensity
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 5)
        {
            sf.enabled = true;
            //joy.SetActive(true);
            //button.SetActive(true);
            for(int i = 0; i< UI.Length; i++)
            {
                UI[i].SetActive(true);
            }
            gameObject.SetActive(false);

        }
    }
}
