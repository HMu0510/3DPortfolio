using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCarma : MonoBehaviour
{

    public float speed = 2.0f;
    public int damage = 5;

    private void OnEnable()
    {
        transform.LookAt(GameObject.Find("Player").transform);

    }
    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log(other.gameObject.name);
            //particle.SetActive(true);
            //pc.transform.position = this.transform.position;
            other.gameObject.GetComponent<PlayerStatus>().HitDamageOnce(damage);
        }
        else
        {
            //Destroy(gameObject);
        }

    }
}
