using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class FloatingFloor : MonoBehaviour
{
    [SerializeField] GameObject cameraPoint;

    private SmoothFollow sf;
    // Start is called before the first frame update
    void Start()
    {
        sf = Camera.main.GetComponent<SmoothFollow>();

        StartCoroutine("CameraSet");
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }
    IEnumerator CameraSet()
    {
        sf.enabled = false;
        yield return new WaitForSeconds(5);
        sf.enabled = true;

        cameraPoint.SetActive(false);
    }
    private void MoveCam()
    {
        if (sf.enabled == false)
        {
            Vector3 dir = transform.position - Camera.main.transform.position;
            dir.Normalize();
            //Camera.main.transform.forward = dir;
            Camera.main.transform.position =
            Vector3.Slerp(Camera.main.transform.position, cameraPoint.transform.position, 3.0f * Time.deltaTime);
            Camera.main.transform.rotation =
                Quaternion.Slerp(Camera.main.transform.rotation, cameraPoint.transform.rotation, 3.0f * Time.deltaTime);
        }
    }
}
