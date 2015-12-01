using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Tower t = this.gameObject.GetComponent<Tower>();

        t.upgradeTower();
        
    }
}
