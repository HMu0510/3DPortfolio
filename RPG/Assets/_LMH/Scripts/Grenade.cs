using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Rigidbody rigid;
    public float power = 100.0f;
    public float expPower = 100.0f;
    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody>();
        Vector3 pos = transform.up + transform.forward;
        rigid.AddForce(pos * power);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Boom");
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(5.0f);
        Explosion();
        Destroy(gameObject);
    }

    private void Explosion()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);

        foreach(Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if(rbody !=null)
            {
                rbody.AddExplosionForce(expPower, transform.position, 10.0f, 300.0f);
            }
        }
    }
}
