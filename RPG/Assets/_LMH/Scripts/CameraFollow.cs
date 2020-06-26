using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    [SerializeField] private Transform target;
    [SerializeField] private Transform tp;
    private float cameraSpeed = 5.0f;
    private bool tpset = false;
    // Start is called before the first frame update
    void Start()
    {
        TPSet();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();

        if (Input.GetKeyDown(KeyCode.F3))
        {
            tpset = true;
            TPSet();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            tpset = false;
            TPSet();
        }

        //transform.position = target.position;
    }
    private void FollowTarget()
    {
        //Vector3 dir = target.position - transform.position;
        //dir.Normalize();  //방향만 쓰는거라 무조건 필요함
        //transform.Translate(dir * cameraSpeed * Time.deltaTime);
        //if(Vector3.Distance(transform.position,target.position) <1)
        //{
        //    target.position = transform.position;
        //}
        if (tpset)
        {
            transform.position = tp.transform.position;
            //transform.rotation = tp.transform.rotation;
        }
        else
        {
            transform.position = target.transform.position;
            //transform.rotation = target.transform.rotation;
        }
    }

    private void TPSet()
    {
        if(tpset)
        {
            transform.position = tp.transform.position;
            //transform.rotation = tp.transform.rotation;
        }
        else
        {
            transform.position = target.transform.position;
            //transform.rotation = target.transform.rotation;
        }
    }
}
