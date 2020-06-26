using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle, Move, Attack, Return, Damaged, Die
    }
    EnemyState state;
    /// <summary>
    /// 써머리
    /// </summary>
    ///
    
    private PlayerMove gp;
    private CharacterController cc;
    #region " Idle state variable "
    public float vision = 20;
    public float hp = 10;
    #endregion
    #region " Move state variable "
    public float moveSpeed = 5;
    #endregion
    #region " Attack state variable "

    public float attRange = 2;
    private float timer;
    private float attTime = 1;
    #endregion
    #region " Return state variable "
    private Vector3 basePos;
    private float rMoveSpeed = 10;
    #endregion
    #region " Damaged state variable "
    #endregion
    #region " Die state variable "
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gp = GameObject.Find("Player").GetComponent<PlayerMove>();
        cc = GetComponent<CharacterController>();
        state = EnemyState.Idle;
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                Idle();      
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
            default:
                break;
        }

    }

    private void Idle()
    {
        //1.플레이어와 일정범위가 되면 이동상태로 변경(탐지)
        //플레이어 찾기 (GameObject.Find("Player")
        //일정거리(20미터) (거리비교  : Distance, magnitude
        //상태변경 state = EnemyState.Move;
        //상태전환 출력 Debug.Log

        //transform.Translate(Vector3.forward * Time.deltaTime);
        if (Vector3.Distance(gp.transform.position, transform.position) <= vision)
        {
            state = EnemyState.Move;
            Debug.Log("Idle to MOVE");
        }
    }

    private void Move()
    {
        //플레이어를 향해 이동 후 공격범위 안에 들어오면 공격상태로 변경
        //플레이어를 추격하더라도 처음위치에서 일정벙위를 넘어가게되면 돌아간다
        //플레이어처럼 캐릭터 컨트롤러를 이용하기
        //상태변경 state = EnemyState.Attack | Return;
        //상태전환 출력 Debug.Log
        Vector3 dir = gp.transform.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        //보간처리
        //transform.forward = Vector3.Lerp(transform.forward, dir, 10 * Time.deltaTime);
        //타겟과 본인이 일직선상일경우 백덤블링으로 회전을 한다
        //최종적으로 자연스런 회전처리를 하려면 결국 쿼터니온을 사용해야 한다
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), moveSpeed * Time.deltaTime);
        //transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * moveSpeed);
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //심플무브는 최소한의 물리가 적용되어 중력문제를 해결할 수 있다
        //단 내부적으로 시간처리를 하기때문에 Time.deltaTime을 사용하지 않는다
        cc.SimpleMove(dir * moveSpeed);
        if(Vector3.Distance(transform.position,basePos) >=vision * 2)
        {
            state = EnemyState.Return;
            Debug.Log("Move to RETURN");
        }
        else if(Vector3.Distance(gp.transform.position, transform.position) <= attRange)
        {
            state = EnemyState.Attack;
            Debug.Log("Move to ATT");
        }

    }

    private void Attack()
    {
        //공격범위설정
        //플레이어가 공격범위를 벗어나면 이동상태(재추격)
        //상태변경 state = EnemyState.Move;
        //상태전환 출력 Debug.Log
        if(Vector3.Distance(transform.position, gp.transform.position) < attRange)
        {
            timer += Time.deltaTime;
            if(timer > attTime)
            {
                print("Attack");
                timer = 0f;
          
            }
        }
        else
        {
            timer = 0f;
            state = EnemyState.Move;
            Debug.Log("Att to Move");
        }
    }

    private void Return()
    {
        //몬스터가 플레이어를 추격하더라도 처음위치에서 일정 범위를 벗어나면 다시 돌아옴
        //일정 범위 설정
        //상태변경 state = EnemyState.Idle;
        //상태전환 출력 Debug.Log
        //Vector3 dir = basePos - transform.position;
        //dir.Normalize();
        //dir.y = 0;
        ////보간처
        //transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * rMoveSpeed);
        //transform.Translate(Vector3.forward * rMoveSpeed * Time.deltaTime);
        //if(Vector3.Distance( basePos,transform.position) <=0.1)
        //{
        //    state = EnemyState.Idle;
        //    Debug.Log("RETURN TO IDLE");
        //}

        if (Vector3.Distance(basePos, transform.position) > 0.1)
        {
            Vector3 dir = (basePos - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), moveSpeed * Time.deltaTime);
            cc.SimpleMove(dir * rMoveSpeed);
        }
        else
        {
            state = EnemyState.Idle;
            Debug.Log("RETURN TO IDLE");
        }


    }
    public void HitDamage(int value)
    {
        if (state == EnemyState.Damaged || state == EnemyState.Die) return;
        hp -= value;
        if(hp>0)
        {
            state = EnemyState.Damaged;
            print("Any STATE TO DAMAGED");
            print("HP : " + hp);
            Damaged();
        }
        else
        {
            state = EnemyState.Die;
            print("DIE");
            Die();
        }
    }
    private void Damaged()
    {
        //어느상황에서도(Die제외) 공격을 받으면 실행되어야하기때문에 코루틴 사용
        //몬스터 체력 1이상
        //다시 이전상태로 변경
        StartCoroutine("DamageProc");
        
    }

    //hit coroutine
    IEnumerator DamageProc()
    {
        yield return new WaitForSeconds(1.0f);
        state = EnemyState.Move;
        print("DAMAGED TO MOVE");
    }

    private void Die()
    {
        //코루틴 사용
        //체력 0 이하
        //오브젝트 삭제
        StopAllCoroutines();

        StartCoroutine("DieProc");
    }

    IEnumerator DieProc()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2.0f);
        print("Enemy Die");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, vision);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(basePos,vision *2 );
    }
}
