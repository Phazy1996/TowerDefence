using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    [SerializeField]
    private float health = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     if( this.health <= 0)
     {
         Destroy(this.gameObject);
     }
	}


    public float getHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }

    }


}
