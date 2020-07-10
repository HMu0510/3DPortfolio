using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    private bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Land"))
        {
            transform.LookAt(player);
        }
        else
        {
            if(!ground)
            {
                transform.Translate(Vector3.down * 4 * Time.deltaTime);
            }
        }
    
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
}
