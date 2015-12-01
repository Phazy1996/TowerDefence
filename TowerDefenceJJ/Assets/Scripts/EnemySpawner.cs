using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> EnemyPrefabs = new List<GameObject>();


    public Wave waveTimer;
    private int enemyCurrentWaveAmount = 0;

    [SerializeField]
    private float spawnCooldown = 1f;

    // Use this for initialization
    void Start()
    {
        waveTimer = GameObject.Find("WaveKeeper").GetComponent<Wave>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waveTimer.getWaveStarted == true && waveTimer.enemyAmountInWave > enemyCurrentWaveAmount)
        {
            SpawnEnemy();
        }
    }


    void SpawnEnemy()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
                enemyCurrentWaveAmount++;
                spawnCooldown = 0.5f;
                Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)], this.gameObject.transform.position, Quaternion.identity);           
        }


    }
    public int currentEnemiesSpawnedInWave
    {
        get
        {
            return enemyCurrentWaveAmount;
        }
        set
        {
            enemyCurrentWaveAmount = value;
        }
    }
}
