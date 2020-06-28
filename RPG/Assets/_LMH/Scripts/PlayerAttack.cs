using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] private Transform attPos;  //Attack Position

    [SerializeField] private GameObject punchEft;
    [SerializeField] private GameObject kickEft;
    [SerializeField] private GameObject upperEft;
    [SerializeField] private GameObject cutEft;

    //public List<GameObject> PoolObj_Jap;
    //public List<GameObject> PoolObj_Kick;
    //public List<GameObject> PoolObj_Upper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Punch()
    {
        GameObject punch = Instantiate(punchEft);
        punch.transform.position = attPos.position;
    }
    public void Kick()
    {
        GameObject kick = Instantiate(kickEft);
        kick.transform.position = attPos.position;
    }
    public void Upper()
    {
        GameObject upper = Instantiate(upperEft);
        upper.transform.position = attPos.position;
    }
    public void Cut()
    {
        GameObject cut = Instantiate(cutEft);
        cut.transform.position = attPos.transform.position;
    }
}
