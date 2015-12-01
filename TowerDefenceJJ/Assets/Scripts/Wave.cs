using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{

    [SerializeField]
    private float waveLengthInSeconds = 5f;

    [SerializeField]
    private int enemySpawnAmount = 5;

    [SerializeField]
    private bool waveStarted = false;

    [SerializeField]
    private float startWaveCooldown = 5f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       

        startNewWave();
        countDownCurrentWave();
        checkForEndOfWave();
        if(checkForEndOfWave() == true)
        {
            resetWave();
        }
       

    }

    public bool checkForEndOfWave()
    {
        if (waveLengthInSeconds < 1)
        {
            return true;  
        }
        else
        {
            return false;
        }
    }

    private void countDownCurrentWave()
    {
        if (waveStarted == true)
        {
            waveLengthInSeconds -= Time.deltaTime;
        }
    }

    private void startNewWave()
    {
        if (startWaveCooldown > 0)
        {
            startWaveCooldown -= Time.deltaTime;
            if (startWaveCooldown <= 0)
            {
                waveStarted = true;
            }
        }
    }

    private void resetWave()
    {
        waveStarted = false;
        waveLengthInSeconds = 5f;
        startWaveCooldown = 5f;
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().currentEnemiesSpawnedInWave = 0;
    }


    public bool getWaveStarted
    {
        get
        {
            return waveStarted;
        }
    }

    public int enemyAmountInWave
    {
        get
        {
            return enemySpawnAmount;
        }
        set
        {
            enemySpawnAmount = value;
        }
    }

}
