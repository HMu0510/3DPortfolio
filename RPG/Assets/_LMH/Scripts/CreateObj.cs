using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    //뭔가 필요없을수도있어요 코드들이 애매.;;;;;;
    [SerializeField] GameObject objBox; //생성용
    public float dis = 5.0f;            //거리
    private Vector3 ob;                 //포지션용
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ob = transform.position;
            //ob = transform.localPosition;   //포지션을 로컬로 바꿈
            GameObject obj = Instantiate(objBox);
            obj.transform.position = ob + transform.forward * dis;
        }
    }
}
