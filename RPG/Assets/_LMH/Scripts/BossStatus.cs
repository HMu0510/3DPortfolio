using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public int hp = 100;



    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(int damage)
    {
        hp -= damage;
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK"))
        {
            anim.SetTrigger("GROGY");
        }
        if(hp <=0)
        {
            hp = 0;
            anim.SetTrigger("DIE");
        }
    }
}
