using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;


    EnergyGaugeFuncs playerEnergyGauge;
    public int rankReached;
    public int currentRank;
    public int milestoneReached;
    public GameObject player;

    public float spawnTimer = 10;

    public GameObject outerDome;
    public Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEnergyGauge = player.GetComponent<EnergyGaugeFuncs>();

        outerDome = GameObject.FindGameObjectWithTag("OuterDome");
        coll = outerDome.GetComponent<Collider>();

        rankReached = 1;
        currentRank = rankReached;
        StartCoroutine(EnemySpawnRoutine());
        //SpreadEnemies();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Timer/10 =" + playerEnergyGauge.timer / 10);
        if ((int)(playerEnergyGauge.timer/10) > milestoneReached)
        {
            milestoneReached = (int)playerEnergyGauge.timer/10;
            rankReached++;
        }

        if (rankReached > currentRank)
        {
            currentRank = rankReached;
            if (spawnTimer > 3)
            {
                spawnTimer = spawnTimer - 0.2f;
            }
        }

    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            Vector3 direction = Random.rotation.eulerAngles;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
            
            if (coll.Raycast(ray, out hit, 1000f))
            {
                Instantiate(enemyPrefab, hit.point, transform.rotation);
                Debug.Log("Spawned Enemy");
                    
            }
                
        }
        
    }
    
}

