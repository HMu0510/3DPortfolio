using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float hp = 100;
    public float stamina = 100;
    private float maxHp;
    private float maxStamina;
    public Animator anim;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
        maxStamina = stamina;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        StaminaOut();
        StaminaRecorvery();
        SetStat();
    }
    public void HitDamageOnce(float damage)
    {
        hp -= damage;
    }
    public void HitDamageTick(float damage)
    {
       
    }
    public void StaminaDown(int stm)
    {
        stamina -= stm;
    }
    public void StaminaOut()
    {
        if(stamina <=0 && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
        {
            stamina = 0;
            anim.SetTrigger("STAMINA");
        }
        
    }
    private void Die()
    {
        if (hp <= 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            hp = 0;
            anim.SetBool("DIE",true);
        }
    }
    private void SetStat()
    {
        if(hp >maxHp)
        {
            hp = maxHp;
        }
        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        hpBar.fillAmount = hp / maxHp;
        staminaBar.fillAmount = stamina / maxHp;
    }
    private void StaminaRecorvery()
    {
        stamina += 5 * Time.deltaTime;
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Down(Stamina)")
            || anim.GetCurrentAnimatorStateInfo(0).IsTag("IDLE")
            || anim.GetCurrentAnimatorStateInfo(0).IsName("WALKF"))
        {
            stamina += 10 * Time.deltaTime;
        }
    }
}
