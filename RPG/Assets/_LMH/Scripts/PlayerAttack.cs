using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform normalAttPos;  //Attack Position
    [SerializeField] private Transform onePunchAttPos;
    [SerializeField] private GameObject punchEft;
    [SerializeField] private GameObject kickEft;
    [SerializeField] private GameObject upperEft;
    [SerializeField] private GameObject cutEft;
    [SerializeField] private GameObject chargeEft;
    [SerializeField] private GameObject shootEft;
    [SerializeField] private GameObject[] fistEft;
    private GameObject charge;
    private GameObject shoot;
    public Animator anim;
    //public List<GameObject> PoolObj_Jap;
    //public List<GameObject> PoolObj_Kick;
    //public List<GameObject> PoolObj_Upper;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        charge = Instantiate(chargeEft);
        charge.SetActive(false);
        shoot = Instantiate(shootEft);
        shoot.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK"))
        {
            for (int i = 0; i < 2; i++)
            {
                fistEft[i].SetActive(true);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("LJap") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LJap1") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RJap") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RJap1") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LHook") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LHook1") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LHook2") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RHook") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RHook1") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RHook2") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LStraight") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("LStraight1") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RStraight") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RStraight1"))
            {
                Punch();

            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("LUpper") ||
                    anim.GetCurrentAnimatorStateInfo(0).IsName("RUpper"))
            {
                Upper();
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("LCut"))
            {
                fistEft[2].SetActive(true);
                Cut();
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("RCut"))
            {
                fistEft[3].SetActive(true);
                Cut();
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("LHKick") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("RHKick") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("SpinKick"))
            {
                Kick();
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Charge"))
            {
                Charge();
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
            {
                Shoot();
            }
        }
        else
        {
            for (int i = 0; i < fistEft.Length; i++)
            {
                fistEft[i].SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

    }
    public void Punch()
    {
        GameObject punch = Instantiate(punchEft);
        punch.transform.position = normalAttPos.position;
    }
    public void Kick()
    {
        GameObject kick = Instantiate(kickEft);
        kick.transform.position = normalAttPos.position;
    }
    public void Upper()
    {
        GameObject upper = Instantiate(upperEft);
        upper.transform.position = normalAttPos.position;
    }
    public void Cut()
    {
        GameObject cut = Instantiate(cutEft);
        cut.transform.position = normalAttPos.transform.position;
    }
    public void Charge()
    {
        shoot.SetActive(false);
        charge.SetActive(true);
        charge.transform.position = onePunchAttPos.transform.position;
    }
    public void Shoot()
    {
        Time.timeScale = 0.1f;
        charge.SetActive(false);
        shoot.SetActive(true);
        shoot.transform.position = onePunchAttPos.transform.position;
        shoot.transform.rotation = this.transform.rotation;
        
    }
    //public void
}
