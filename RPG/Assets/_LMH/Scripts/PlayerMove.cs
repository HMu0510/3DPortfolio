using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float dodgeSpeed = 10.0f;
    public float jumpPower = 5;
    private float velrocityY;
    private int jumpCount;
    private bool jump = false;
    public float gravity = -9.8f;
    private Vector3 dir;
    private Rigidbody rg;
    private Quaternion rot;
    private Animator anim;
    private CharacterController cc; //chractercontroller
    [SerializeField]private PlayerRotate pR;
    [SerializeField]private ButtonEvent bE;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rg = GetComponent<Rigidbody>();
        pR = GetComponent<PlayerRotate>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpCheck();
        Move();
        if(Input.GetButtonDown("Jump"))
        {
            Jump();

        }
    }
    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

       dir = new Vector3(h,0,v);       //ㄷㅐ각선 이동 속도를 상하좌우속도와 동일하게 만들기
        //게임에 따라 일부러 대각선은 빠르게 이동하도록 하는 경우도 있다.
        //이럴때는 벡터의 정규화를 하면 안된다.
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        
        //transform.Translate(dir * speed * Time.deltaTime);


        //if(cc.isGrounded)
        if(cc.collisionFlags == CollisionFlags.Below)//Above // Below // Sides
        {
            print("INGROUND");
            jump = false;
            jumpCount = 0;
            velrocityY = 0;
            //dir.y = velrocityY;
        }
        if (h != 0 || v != 0)
        {
            //rot.eulerAngles = new Vector3(0, (Mathf.Atan2(h, v) * Mathf.Rad2Deg) + 90, 0);
            rot.eulerAngles = new Vector3(0, (Mathf.Atan2(h, v) * Mathf.Rad2Deg) + Camera.main.transform.rotation.eulerAngles.y, 0);

            //transform.rotation = Quaternion.LookRotation(dir);
            if (!anim.GetBool("ATTACK") && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
            {
                bE.RUN();
            }
            else
            {
                dir.x = 0;
                dir.z = 0; 
            }
        }
        else
        {
            bE.IDLE();
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            velrocityY = jumpPower;
            Debug.Log(velrocityY);
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RUpper") && !anim.GetCurrentAnimatorStateInfo(0).IsName("LUpper"))
        {
            velrocityY += gravity * Time.deltaTime;
        }
        dir.y = velrocityY;
        cc.Move(dir *speed* Time.deltaTime);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            pR.Rotate(rot);
        }
    }

    public void Move(Vector3 dir,float moveSpeed)
    {
        if(jump)
        {
            Debug.Log("JUMPMOVE");
            dir.y += gravity; 
            cc.Move(dir * moveSpeed*Time.deltaTime);
        }
        else
        {
            Debug.Log("MOVE"+dir);
            dir.y = 0;
            cc.Move(dir * moveSpeed*Time.deltaTime); 
        }
        //transform.Translate(dir * moveSpeed * Time.deltaTime);
             //애니메이션 플레이
    }

    public void JumpCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * 0.05f, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 0.05f))
        {
            if (hit.collider.tag == "Ground")
            {
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Down"))
                {
                    anim.SetTrigger("LAND");
                }

                //print("GROUND");
                jump = false;
                //velrocityY = 0;
            }
            
        }
        if (cc.collisionFlags == CollisionFlags.Below)//Above // Below // Sides
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Down"))
            {
                anim.SetTrigger("LAND");
            }
            //print("INGROUND");
            jump = false;
            //velrocityY = 0;
        }
        if(jump)
        {
            Debug.Log("JUMPIN");
            velrocityY += gravity * Time.deltaTime;

            //cc.Move(velrocityY*Time.deltaTime);
            //transform.Translate(Vector3.up * gravity * Time.deltaTime);
        }
        else
        {
            //velrocityY = 0;
            //cc.Move(velrocityY * Time.deltaTime);

        }
        if (velrocityY <0)
        {
            anim.SetTrigger("DOWN");
        }

    }

    public void Jump()
    {
        if (!jump)
        {
            Debug.Log("JUMP!");
            jump = true;
            //rg.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    public void Dodge(Vector3 dir)
    {
        cc.SimpleMove(dir * dodgeSpeed);
    }

   
}