//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public float range = 2;
    public int maxEnemy = 3;
    public int maxSpawnCount = 5;
    private int count,maxCount;
    //private Queue<GameObject> enemyBox;
    public List<GameObject> enemyBox;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxEnemy; i++)
        {
            InitEnemy();
        }
        //InitQueue();
        //for(int i = 0; i < maxEnemy; i++)
        //{
        //    PopQueue();
        //}\
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCheck();
        if (count != maxEnemy && maxCount < maxSpawnCount)
        {
            Debug.Log("PLAY");
            count++;
            StartCoroutine("CreateEnemy");
        }

    }
    private void EnemyCheck()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 1.5f*range);
        for(int i = 0; i < colls.Length; i++)
        {
            if(colls[i].gameObject.name.Contains("EnemyTest"))
            {
                Debug.Log("IN");
                count++;
            }
        }

    }
    IEnumerator CreateEnemy()
    {
        maxCount++;
        Debug.Log(maxCount);
        yield return new WaitForSeconds(5.0f);
        //enemy setActive true
        //PopQueue();
        EnemyActive();

    }

    private void EnemyActive()
    {
        for(int i = 0; i < maxEnemy; i++)
        {
            if(enemyBox[i].activeSelf == false)
            {

                enemyBox[i].SetActive(true);
                enemyBox[i].transform.position = new Vector3(transform.position.x + Random.Range(-range, range),
                       transform.position.y, transform.position.z + Random.Range(-range, range));
                break;

            }
        }
    }
    //private void InitQueue()
    //{
    //    for(int i = 0; i < maxEnemy; i++)
    //    {
    //        GameObject enemyPre = Instantiate(enemy);
    //        enemyPre.SetActive(false);
    //        enemyPre.transform.SetParent(this.transform);
    //        enemyBox.Enqueue(enemyPre);
    //    }
    //}
    //private void PopQueue()
    //{
    //    GameObject enemyPre = enemyBox.Dequeue();
    //    enemyPre.SetActive(true);
    //    enemyPre.transform.position = new Vector3(transform.position.x + Random.Range(-range, range),
    //        transform.position.y, transform.position.z + Random.Range(-range, range));
    //    
    //}

    private void InitEnemy()
    {
        GameObject enemyPre = Instantiate(enemy,this.transform);
        enemyPre.SetActive(false);
        enemyBox.Add(enemyPre);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
