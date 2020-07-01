using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoint;
    [SerializeField] private GameObject player;
    public PlayerHit playerHit;
    private float dis;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        playerHit = GetComponent<PlayerHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= -8)
        {
            dis = Vector3.Distance(player.transform.position, spawnPoint[0].transform.position);
            index = 0;
            for(int i = 1; i < spawnPoint.Length; i++)
            {
               float temp = Vector3.Distance(player.transform.position,
                    spawnPoint[i].transform.position);
                if(temp < dis)
                {
                    dis = temp;
                    index = i;
                }
            }
            player.transform.position = spawnPoint[index].transform.position;
            playerHit.HitDamageOnce(5);
        }
    }
}
