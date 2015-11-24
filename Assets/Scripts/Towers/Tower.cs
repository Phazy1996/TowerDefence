using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	[SerializeField]
	float range;
	[SerializeField]
	float fireRate;
	[SerializeField]
	float nextFire;
	[SerializeField]
	float damage;
	[SerializeField]
	private GameObject bullet;

	//UPGRADE
	[SerializeField]
	private GameObject[] upgradeSelection;
	private bool isClicked;
	private SpriteRenderer invisible;


	void Awake(){
		invisible = GetComponent<SpriteRenderer> ();
	}

	//UPGRADE

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
		foreach (Collider2D enemy in enemies) {

			if (enemy.gameObject.tag == "Enemy" && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				GameObject target = enemy.gameObject;
				Health targetHealth = target.GetComponent<Health> ();


				if (targetHealth != null && targetHealth.GetHealth > 0) {
					enemy.gameObject.SendMessage("ApplyDamage",damage);
					Debug.Log ("pew to: " + target.name);
				}
				//Vector2.MoveTowards(this.gameObject, gameObject.tag==("Enemy"), range);	//Bullet with moveTo. 
			}
		}
	}
	//UPGRADE
	void OnMouseDown (){
		if (isClicked) 
		{
			Instantiate(upgradeSelection[0],transform.position,transform.rotation);
			invisible.color = new Color (1f,1f,1f,0f);
			isClicked = true;
		}
	}
	//UPGRADE
}