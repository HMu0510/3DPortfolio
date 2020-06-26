using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLRMove : MonoBehaviour
{
    private bool leftMove;
    public bool startLeft = true;
    public float length = 5;
    private float pos;
    // Start is called before the first frame update
    void Start()
    {
        if (startLeft)
        {
            leftMove = true;
        }
        else
        {
            leftMove = false;
        }
        pos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftMove)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (startLeft)
        {
            if (transform.position.x <= pos - length)
            {
                leftMove = false;
            }
            if (transform.position.x >= pos)
            {
                leftMove = true;
            }
        }
        else
        {
            if (transform.position.x <= pos)
            {
                leftMove = false;
            }
            if (transform.position.x >= pos + length)
            {
                leftMove = true;
            }
        }
    }

}
