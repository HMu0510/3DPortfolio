using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCarma : MonoBehaviour
{
    public float speed = 2.0f;
    public float damage = 5.0f;
    public float lifeTime = 1.0f;
    [SerializeField] private GameObject particle;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        //particle = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        if(Vector3.Distance(pos,transform.position) >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.transform.tag == "Enemy")
    //    {
    //        //collision.gameObject.GetComponent<HitDamage>().add(damage);
    //        //particle.SetActive(true);
    //        Destroy(gameObject, 1.0f);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ENEMY"))
        {
            particle.SetActive(true);
            //other.gameObject.GetComponent<>
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

}
