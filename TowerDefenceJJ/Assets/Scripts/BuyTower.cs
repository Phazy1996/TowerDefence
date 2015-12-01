using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BuyTower : MonoBehaviour {

    [SerializeField]
    private GameObject towerPrefab;


	// Use this for initialization
	void Start () {
        
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        CreateTowerAtPoint();
    }


    public void CreateTowerAtPoint()
    {
        Debug.Log("spawnin ze tower");
        SelectTowerPoint[] towerPoint = FindObjectsOfType<SelectTowerPoint>();
        for (int i = 0; i < towerPoint.Length; i++)
        {
            if (towerPoint[i].GetClicked == true)
            {
                GameObject newTower = Instantiate(towerPrefab, towerPoint[i].transform.position, Quaternion.identity) as GameObject;
                towerPoint[i].GetClicked = false;
            }
        }
       
    }
}
