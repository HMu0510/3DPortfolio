using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject cameraPoint;
    private SmoothFollow sf;

    // Start is called before the first frame update
    void Start()
    {
        sf = Camera.main.GetComponent<SmoothFollow>();
        StartCoroutine("CameraSet");
        StartCoroutine("SpawnSet");
        StartCoroutine("BossSet");
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }
    IEnumerator SpawnSet()
    {
        yield return new WaitForSeconds(1);
        spawnPoint.SetActive(true);
        yield return new WaitForSeconds(3);
        spawnPoint.SetActive(false);
    }
    IEnumerator BossSet()
    {
        yield return new WaitForSeconds(3);
        boss.SetActive(true);

    }
    IEnumerator CameraSet()
    {
        sf.enabled = false;
        yield return new WaitForSeconds(5);
        sf.enabled = true;
        sf.height = 10.0f;
        sf.distance = 10.0f;
        sf.rotationDamping = 0;
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
            Vector3.Slerp(Camera.main.transform.position, cameraPoint.transform.position, 2.0f * Time.deltaTime);
            Camera.main.transform.rotation =
                Quaternion.Slerp(Camera.main.transform.rotation, cameraPoint.transform.rotation, 2.0f * Time.deltaTime);
        }
    }
}
