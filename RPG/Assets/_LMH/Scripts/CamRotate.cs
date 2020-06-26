using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //camera mouse move dir rotate
   private float angleX;
    private float angleY;
    public float speed = 150;// rotate speed (time.deltatime to 1sec 150digree
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        Vector3 dir = new Vector3(-v, h, 0); //cuck bang hyang
        //transform.Rotate(dir * speed * Time.deltaTime);


        //gymberl lock

        //so we use transform.eulerangles
        //transform.eulerAngles += dir * speed * Time.deltaTime;

        //Vector3 angle = transform.eulerAngles;
        //angle += dir * speed * Time.deltaTime;
        //if (angle.x > 60) angle.x = 60;
        //if (angle.x < -60) angle.x = -60;
        //
        //transform.eulerAngles = angle;
        angleX += h * speed * Time.deltaTime;
        angleY += v * speed * Time.deltaTime;
        angleY = Mathf.Clamp(angleY, -60, 60);
        transform.eulerAngles = new Vector3(-angleY, angleX, 0);
    }
}
