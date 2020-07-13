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
    private List<GameObject> punch;
    private List<GameObject> kick;
    private GameObject upper;
    private GameObject cut;
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
        punch = new List<GameObject>();
        kick = new List<GameObject>();
        for(int i = 0; i < 3; i++)
        {
            GameObject punchSet = Instantiate(punchEft,GameObject.Find("PoolingObject").transform);
            punchSet.SetActive(false);
            punch.Add(punchSet);
            GameObject kickSet = Instantiate(kickEft,GameObject.Find("PoolingObject").transform);
            kickSet.SetActive(false);
            kick.Add(kickSet);
        }
        upper = Instantiate(upperEft, GameObject.Find("PoolingObject").transform);
        upper.SetActive(false);
        cut = Instantiate(cutEft, GameObject.Find("PoolingObject").transform);
        cut.SetActive(false);
        charge = Instantiate(chargeEft, GameObject.Find("PoolingObject").transform);
        charge.SetActive(false);
        shoot = Instantiate(shootEft, GameObject.Find("PoolingObject").transform);
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
        for(int i = 0; i < punch.Count; i++)
        {
            if(!punch[i].activeSelf)
            {
                punch[i].SetActive(true);
                punch[i].transform.position = normalAttPos.position;
                punch[i].transform.rotation = this.transform.rotation;
                break;
            }
        }
    }
    public void Kick()
    {
        for (int i = 0; i < kick.Count; i++)
        {
            if (!kick[i].activeSelf)
            {
                kick[i].SetActive(true);
                kick[i].transform.position = normalAttPos.position;
                break;
            }
        }
    }
    public void Upper()
    {
        upper.SetActive(true);
        upper.transform.position = normalAttPos.position;
        upper.transform.rotation = this.transform.rotation;
    }
    public void Cut()
    {
        cut.SetActive(true);
        cut.transform.position = normalAttPos.position;
        cut.transform.position = this.transform.position;

    }
    public void Charge()
    {
        shoot.SetActive(false);
        charge.SetActive(true);
        charge.transform.position = onePunchAttPos.transform.position;
    }
    public void Shoot()
    {
        Time.timeScale = 0.3f;
        charge.SetActive(false);
        shoot.SetActive(true);
        shoot.transform.position = onePunchAttPos.transform.position;
        shoot.transform.rotation = this.transform.rotation;
        
    }
    //public void
}
