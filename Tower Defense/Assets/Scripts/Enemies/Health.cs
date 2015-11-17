using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp = 5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (hp > 0) {
			//continue movement to target
		}
	}

	void ApplyDamage (int damage) {
		hp -= damage;
		if(hp<=0){
			Destroy(this.gameObject);//Destroy gameobject
		}
	}

	public int GetHealth
	{
		get
		{
			return hp;
		}
		set
		{
			hp = value;
		}
		
	}

}