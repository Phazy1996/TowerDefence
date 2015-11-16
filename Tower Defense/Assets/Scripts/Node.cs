using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {


    private Vector2 pos;

	// Use this for initialization
	void Start () {
	    
        pos = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector2 GetNodePosition
    {
        get
        {
            return pos;
        }
    }
   

    


}
