using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainEvent : MonoBehaviour
{

    [SerializeField] BoxUDMove budm;
    [SerializeField] BoxLRMove blrm;
    [SerializeField] AutoRotary[] autoRotaris;
    [SerializeField] GameObject[] eSpawn;
    [SerializeField] GameObject bossSpawn;
    [SerializeField] FloatingFloor floor;
    [SerializeField] GameObject playerSpawnPoint;
    private bool active = false; 
    private int maxEnemyCount;
    public int clearEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < eSpawn.Length; i++)
        {
            maxEnemyCount += eSpawn[i].GetComponent<EnemySpawn>().maxSpawnCount;
        }
        floor = GetComponent<FloatingFloor>();
        print("maxECount : " + maxEnemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        BossMapSpawnPoint();

        if (maxEnemyCount <= clearEnemyCount && !active)
        {
            StartCoroutine("ActtiveSetPoint");
            StartCoroutine("SetPlay");
            active = true;
        }

    }
    private void BossMapSpawnPoint()
    {
        if (GameObject.Find("Player").transform.position.x >= playerSpawnPoint.transform.position.x)
        {
            playerSpawnPoint.SetActive(true);
            bossSpawn.SetActive(true);
        }
    }
    IEnumerator ActtiveSetPoint()
    {
        floor.enabled = true;
        yield return new WaitForSeconds(5);
        floor.enabled = false;
    }
    IEnumerator SetPlay()
    {

        yield return new WaitForSeconds(2);
        budm.enabled = true;
        blrm.enabled = true;
        for (int i = 0; i < autoRotaris.Length; i++)
        {
            autoRotaris[i].enabled = true;
        }

    }
}
