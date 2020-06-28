using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    public ButtonEvent bt;
    // Start is called before the first frame update
    void Start()
    {
        bt = GetComponent<ButtonEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <=0)
        {
            hp = 0;
            Die();
        }            
    }
    public void HitDamageOnce(float damage)
    {
        hp -= damage;
    }
    public void HitDamageTick(float damage)
    {
       
    }
    private void Die()
    {
        bt.Die();
    }
}
