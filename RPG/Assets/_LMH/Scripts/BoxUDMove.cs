using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUDMove : MonoBehaviour
{
    private bool upMove;
    public bool startUp = true;
    public float length = 5;
    private float pos;
    // Start is called before the first frame update
    void Start()
    {
        if(startUp)
        {
            upMove = true;
        }
        else
        {
            upMove = false;
        }
        pos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(upMove)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        if(startUp)
        {
            if(transform.position.y >= pos + length)
            {
                upMove = false;
            }
            if(transform.position.y <= pos)
            {
                upMove = true;
            }
        }
        else
        {
            if (transform.position.y >= pos)
            {
                upMove = false;
            }
            if (transform.position.y <= pos - length)
            {
                upMove = true;
            }
        }
    }
    
}
