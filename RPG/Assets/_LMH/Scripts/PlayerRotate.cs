using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    //public float speed = 150;
    public float rotSpeed = 15.0f;
    private float angleX;
    // Start is called before the first frame update

    public void Rotate(Quaternion dir)
    {
        //float h = Input.GetAxis("Mouse X");
        //angleX += h * speed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, angleX, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, rotSpeed * Time.deltaTime);
        //transform.rotation = dir;
    }
}