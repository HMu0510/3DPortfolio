using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCarma : MonoBehaviour
{
    public float speed = 2.0f;
    public float damage = 5.0f;
    public float lifeTime = 1.0f;
    private GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<HitDamage>().add(damage);
            particle.SetActive(true);
            Destroy(gameObject, 1.0f);
        }
    }

}
