using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> EnemyPrefabs = new List<GameObject>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnEnemies();
        }
    }


    void SpawnEnemies()
    {

        Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)]);

    }

}
