using UnityEngine;
using System.Collections;

public class TowerShoot : MonoBehaviour {
	float range = 2f;
	float fireRate = 1f;
	float nextFire;
	float damage = 1f;
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
			}
		}
	}
}